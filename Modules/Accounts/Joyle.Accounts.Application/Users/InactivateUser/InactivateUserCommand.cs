using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.Users.InactivateUser
{
    public class InactivateUserCommand : CommandBase
    {
        public Guid UserId { get; }

        public InactivateUserCommand(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
