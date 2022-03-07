using Joyle.BuildingBlocks.Domain;
using System;

namespace Joyle.Accounts.Domain.PasswordRecoveries.Events
{
    public class PasswordRecoveryRequestedDomainEvent : DomainEvent
    {
        public Email Email { get; }
        public Guid PasswordRecoveryId { get; }
        public string RecoveryLink { get; }

        public PasswordRecoveryRequestedDomainEvent(
            Email email,
            Guid passwordRecoveryId,
            string recoveryLink)
        {
            Email = email;
            PasswordRecoveryId = passwordRecoveryId;
            RecoveryLink = recoveryLink;
        }
    }
}
