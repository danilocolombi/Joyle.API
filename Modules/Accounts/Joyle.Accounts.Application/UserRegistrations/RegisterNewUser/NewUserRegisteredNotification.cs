using Joyle.Accounts.Application.UserRegistrations.SendUserRegistrationConfirmationEmail;
using Joyle.Accounts.Domain.UserRegistrations.Events;
using Joyle.BuildingBlocks.Application.Mediator;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredNotification : INotificationHandler<NewUserRegisteredDomainEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public NewUserRegisteredNotification(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(NewUserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.ExecuteCommandAsync(new SendUserRegistrationConfirmationEmailCommand(
                  notification.UserRegistrationId,
                  notification.FullName,
                  notification.Email,
                  notification.ConfirmationLink));
        }
    }
}
