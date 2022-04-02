using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using Joyle.Games.Domain.Cardashians.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Games.Application.Cardashians.RenameCardashian
{
    public class RenameCardashianCommandHandler : ICommandHandler<RenameCardashianCommand>
    {
        private readonly ICardashianRepository _cardashianRepository;

        public RenameCardashianCommandHandler(ICardashianRepository cardashianRepository)
        {
            _cardashianRepository = cardashianRepository;
        }

        public async Task<Unit> Handle(RenameCardashianCommand request, CancellationToken cancellationToken)
        {
            var cardashian = await _cardashianRepository.FindAsync(request.CardashianId);

            if (cardashian == null)
                throw new CommandInvalidException("Invalid Cardashian");

            cardashian.Rename(request.AuthorId, request.Title);

            await _cardashianRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
