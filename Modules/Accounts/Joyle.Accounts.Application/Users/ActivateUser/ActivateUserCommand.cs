using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.Users.ActivateUser
{
    public class ActivateUserCommand : CommandBase
    {
        public Guid UserId { get; }

        public ActivateUserCommand(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
