using Joyle.Accounts.Domain;
using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.PasswordRecoveries.SendPasswordRecoveryEmail
{
    public class SendPasswordRecoveryEmailCommand : CommandBase
    {
        public Guid PasswordRecoveryId { get; }
        public string RecoveryLink { get; }
        public Email Email { get; }

        public SendPasswordRecoveryEmailCommand(Guid passwordRecoveryId, string recoveryLink, Email email)
        {
            PasswordRecoveryId = passwordRecoveryId;
            RecoveryLink = recoveryLink;
            Email = email;
        }
    }
}
