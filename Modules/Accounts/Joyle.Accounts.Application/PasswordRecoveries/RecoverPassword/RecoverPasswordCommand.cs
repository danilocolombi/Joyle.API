using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.PasswordRecoveries.RecoverPassword
{
    public class RecoverPasswordCommand : CommandBase
    {
        public Guid PasswordRecoveryId { get; }
        public string Password { get; }

        public RecoverPasswordCommand(Guid passwordRecoveryId, string newPassword)
        {
            PasswordRecoveryId = passwordRecoveryId;
            Password = newPassword;
        }
    }
}
