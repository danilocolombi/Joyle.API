using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.ChangeCardashianCardDescription
{
    public class ChangeCardashianCardDescriptionCommandHandler : ICommandHandler<ChangeCardashianCardDescriptionCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public ChangeCardashianCardDescriptionCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(ChangeCardashianCardDescriptionCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            cardashian.ChangeCardDescription(request.AuthorId, request.CardId, request.Description);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
