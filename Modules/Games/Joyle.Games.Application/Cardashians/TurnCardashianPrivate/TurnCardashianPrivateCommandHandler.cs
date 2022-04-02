using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.TurnCardashianPrivate
{
    public class TurnCardashianPrivateCommandHandler : ICommandHandler<TurnCardashianPrivateCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public TurnCardashianPrivateCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(TurnCardashianPrivateCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            cardashian.TurnPrivate(request.AuthorId);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
