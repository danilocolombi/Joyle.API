using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.DeleteCardashian
{
    public class DeleteCardashianCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }

        public DeleteCardashianCommand(
            Guid cardashianId,
            Guid authorId)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
        }
    }
}
