using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.AddCardashianCard
{
    public class AddCardashianCardCommand : CommandBase
    {
        public Guid CardashianId { get; }
        public Guid AuthorId { get; }
        public string Description { get; }

        public AddCardashianCardCommand(
            Guid cardashianId,
            Guid authorId,
            string description)
        {
            CardashianId = cardashianId;
            AuthorId = authorId;
            Description = description;
        }
    }
}
