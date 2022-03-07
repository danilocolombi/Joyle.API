using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : CommandBase
    {
        public Guid UserId { get; }
        public string CurrentPassword { get; }
        public string NewPassword { get; }

        public ChangeUserPasswordCommand(Guid userId, string currentPassword, string newPassword)
        {
            UserId = userId;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
