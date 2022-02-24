using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommand : CommandBase
    {
        public Guid RegistrationId { get; }

        public ConfirmUserRegistrationCommand(Guid registrationId)
        {
            RegistrationId = registrationId;
        }
    }
}
