using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.RenameCardashian
{
    public class RenameCardashianCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }
        public string Title { get; }

        public RenameCardashianCommand(
            Guid cardashianId,
            Guid authorId,
            string title)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
            Title = title;
        }
    }
}
