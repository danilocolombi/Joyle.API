using Joyle.Accounts.Domain.PasswordRecoveries.Events;
using Joyle.BuildingBlocks.Domain;
using System;

namespace Joyle.Accounts.Domain.PasswordRecoveries
{
    public class PasswordRecovery : Entity, IAggregateRoot
    {
        public Email Email { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public PasswordRecoveryStatus Status { get; private set; }
        public DateTime? RecoveryDate { get; private set; }

        private const int RecoveryTimeInHours = 24;

        protected PasswordRecovery() { }

        private PasswordRecovery(
            Email email,
            string recoveryLink)
        {
            Id = Guid.NewGuid();
            Email = email;
            CreationDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddHours(RecoveryTimeInHours);
            Status = PasswordRecoveryStatus.Requested;

            AddDomainEvent(new PasswordRecoveryRequestedDomainEvent(email, Id, recoveryLink));
        }

        public static PasswordRecovery Request(
            Email email,
            string recoveryLink)
        {
            return new PasswordRecovery(email, recoveryLink);
        }

        public void Recover(string newPassword)
        {
            if (IsExpired())
                throw new BusinessRuleValidationException("This password recovery has expired");

            if (this.Status == PasswordRecoveryStatus.Recovered)
                throw new BusinessRuleValidationException("This password recovery was already used");

            this.Status = PasswordRecoveryStatus.Recovered;
            this.RecoveryDate = DateTime.Now;

            AddDomainEvent(new PasswordRecoveredDomainEvent(this.Email, newPassword));
        }

        private bool IsExpired()
            => DateTime.Now > ExpirationDate;
    }
}
