using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.AddCardashianCard
{
    public class AddCardashianCardCommandHandler : ICommandHandler<AddCardashianCardCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public AddCardashianCardCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(AddCardashianCardCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            cardashian.AddCard(request.AuthorId, request.Description);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
