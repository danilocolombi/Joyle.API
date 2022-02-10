using Joyle.Accounts.Domain;
using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    public class SendUserRegistrationConfirmationEmailCommand : CommandBase
    {
        public Guid UserRegistrationId { get; }
        public string FullName { get; }
        public Email Email { get; }
        public string ConfirmationLink { get; }

        public SendUserRegistrationConfirmationEmailCommand(Guid userRegistrationId, string fullName, Email email, string confirmationLink)
        {
            UserRegistrationId = userRegistrationId;
            FullName = fullName;
            Email = email;
            ConfirmationLink = confirmationLink;
        }
    }
}
