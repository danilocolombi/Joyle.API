using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.TurnCardashianPublic
{
    public class TurnCardashianPublicCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }

        public TurnCardashianPublicCommand(
            Guid cardashianId,
            Guid authorId)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
        }
    }
}
