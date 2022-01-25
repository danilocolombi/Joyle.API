using Joyle.BuildingBlocks.Domain;
using System;

namespace Joyle.Accounts.Domain.UserRegistrations.Events
{
    public class NewUserRegisteredDomainEvent : DomainEvent
    {
        public Guid UserRegistrationId { get; }
        public string FullName { get; }
        public Email Email { get; }
        public string ConfirmationLink { get; }

        public NewUserRegisteredDomainEvent(Guid userRegistrationId, string fullName, Email email, string confirmationLink)
        {
            UserRegistrationId = userRegistrationId;
            FullName = fullName;
            Email = email;
            ConfirmationLink = confirmationLink;
        }
    }
}
