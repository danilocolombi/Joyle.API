using Dapper;
using Joyle.BuildingBlocks.Application.Data;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.GetCardashian
{
    public class GetCardashianQueryHandler : IQueryHandler<GetCardashianQuery, CardashianDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetCardashianQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<CardashianDto> Handle(GetCardashianQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var connection = _sqlConnectionFactory.GetOpenConnection();

                var sql = $@"SELECT  Cardashian.Id AS {nameof(CardashianDto.Id)},
                        Cardashian.Title AS {nameof(CardashianDto.Title)},
                        Cardashian.IsPublic AS {nameof(CardashianDto.IsPublic)},
                        Cardashian.CreationDate AS {nameof(CardashianDto.CreationDate)},
                        CardashianCard.Id AS {nameof(CardashianCardDto.Id)},
                        CardashianCard.Description AS {nameof(CardashianCardDto.Description)},
                        CardashianCard.Position AS {nameof(CardashianCardDto.Position)}
                        FROM dbo.Cardashian
                        LEFT JOIN dbo.CardashianCard ON Cardashian.Id = CardashianCard.CardashianId
                        WHERE Cardashian.Id = @cardashianId";

                var cardashianDictionary = new Dictionary<Guid, CardashianDto>();
                var cardashian = await connection.QueryAsync<CardashianDto, CardashianCardDto, CardashianDto>(
                     sql,
                     (cardashian, card) =>
                     {
                         CardashianDto cardashianEntry;

                         if (!cardashianDictionary.TryGetValue(cardashian.Id, out cardashianEntry))
                         {
                             cardashianEntry = cardashian;
                             cardashianEntry.Cards = new List<CardashianCardDto>();
                             cardashianDictionary.Add(cardashianEntry.Id, cardashianEntry);
                         }

                         cardashianEntry.Cards.Add(card);

                         return cardashianEntry;
                     },
                      new { cardashianId = request.CardashianId },
                     splitOn: "Id");


                return cardashian?.Distinct().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
