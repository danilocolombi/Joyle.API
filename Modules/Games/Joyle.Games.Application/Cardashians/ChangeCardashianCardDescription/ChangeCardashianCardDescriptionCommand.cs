using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.ChangeCardashianCardDescription
{
    public class ChangeCardashianCardDescriptionCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }
        public Guid CardId { get; }
        public string Description { get; }

        public ChangeCardashianCardDescriptionCommand(
            Guid cardashianId,
            Guid authorId,
            Guid cardId,
            string description)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
            CardId = cardId;
            Description = description;
        }
    }
}
