using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.RemoveCardashianCard
{
    public class RemoveCardashianCardCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }
        public Guid CardId { get; }

        public RemoveCardashianCardCommand(
            Guid cardashianId,
            Guid authorId,
            Guid cardId)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
            CardId = cardId;
        }
    }
}
