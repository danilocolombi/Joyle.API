using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.ChangeCardashianCardPosition
{
    public class ChangeCardashianCardPositionCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }
        public Guid CardId { get; }
        public int Position { get; }

        public ChangeCardashianCardPositionCommand(
            Guid cardashianId,
            Guid authorId,
            Guid cardId,
            int position)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
            CardId = cardId;
            Position = position;
        }
    }
}
