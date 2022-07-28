using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians;
using Joyle.Games.Domain.Cardashians.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.CreateCardashian
{
    public class CreateCardashianCommandHandler : ICommandHandler<CreateCardashianCommand, Guid>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public CreateCardashianCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Guid> Handle(CreateCardashianCommand request, CancellationToken cancellationToken)
        {
            var cardashian = Cardashian.NewCardashian(request.Title, request.IsPublic, request.AuthorId);

            await _cardashianRepository.AddAsync(cardashian);

            await _cardashianRepository.UnitOfWork.Commit();

            return cardashian.Id;
        }
    }
}
