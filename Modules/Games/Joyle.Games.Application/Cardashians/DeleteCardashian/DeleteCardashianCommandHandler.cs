using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.DeleteCardashian
{
    public class DeleteCardashianCommandHandler : ICommandHandler<DeleteCardashianCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public DeleteCardashianCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(DeleteCardashianCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            if (!cardashian.IsAuthor(request.AuthorId))
                throw new CommandInvalidException("Invalid Author");

            _cardashianRepository.Remove(cardashian);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
