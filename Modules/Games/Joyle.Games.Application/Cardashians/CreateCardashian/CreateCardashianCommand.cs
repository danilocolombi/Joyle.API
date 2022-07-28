
using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Games.Application.Cardashians.CreateCardashian
{
    public class CreateCardashianCommand : CommandBase<Guid>
    {
        public string Title { get; }
        public bool IsPublic { get; }
        public Guid AuthorId { get; }

        public CreateCardashianCommand(
            string title,
            bool isPublic,
            Guid authorId)
        {
            Title = title;
            IsPublic = isPublic;
            AuthorId = authorId;
        }
    }
}
