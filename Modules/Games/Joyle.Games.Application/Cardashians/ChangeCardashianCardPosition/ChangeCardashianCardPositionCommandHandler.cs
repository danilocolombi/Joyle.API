using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.ChangeCardashianCardPosition
{
    public class ChangeCardashianCardPositionCommandHandler: ICommandHandler<ChangeCardashianCardPositionCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public ChangeCardashianCardPositionCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(ChangeCardashianCardPositionCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            cardashian.ChangeCardPosition(request.AuthorId, request.CardId, request.Position);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
