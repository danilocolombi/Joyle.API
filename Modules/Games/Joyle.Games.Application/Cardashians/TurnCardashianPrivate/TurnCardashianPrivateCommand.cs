using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.TurnCardashianPrivate
{
    public class TurnCardashianPrivateCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }

        public TurnCardashianPrivateCommand(
            Guid cardashianId,
            Guid authorId)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
        }
    }
}
