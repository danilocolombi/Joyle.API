using Joyle.BuildingBlocks.Domain;

namespace Joyle.Accounts.Domain.UserRegistrations.Events
{
    public class UserRegistrationConfirmedDomainEvent : DomainEvent
    {
        public UserRegistration UserRegistration { get; }

        public UserRegistrationConfirmedDomainEvent(UserRegistration userRegistration)
        {
            this.UserRegistration = userRegistration;
        }
    }
}
