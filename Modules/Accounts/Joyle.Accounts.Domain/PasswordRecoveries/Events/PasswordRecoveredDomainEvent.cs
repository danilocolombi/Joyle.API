using Joyle.BuildingBlocks.Domain;

namespace Joyle.Accounts.Domain.PasswordRecoveries.Events
{
    public class PasswordRecoveredDomainEvent : DomainEvent
    {
        public Email Email { get; }
        public string Password { get; }

        public PasswordRecoveredDomainEvent(Email email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
