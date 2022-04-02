using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.RemoveCardashianCard
{
    public class RemoveCardashianCardCommandHandler : ICommandHandler<RemoveCardashianCardCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public RemoveCardashianCardCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(RemoveCardashianCardCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            cardashian.RemoveCard(request.AuthorId, request.CardId);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
