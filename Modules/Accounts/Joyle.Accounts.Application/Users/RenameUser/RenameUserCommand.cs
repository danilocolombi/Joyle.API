using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.Users.RenameUser
{
    public class RenameUserCommand : CommandBase
    {
        public Guid UserId { get; }
        public string FullName { get; }

        public RenameUserCommand(
            Guid userId,
            string fullName)
        {
            UserId = userId;
            FullName = fullName;
        }
    }
}
