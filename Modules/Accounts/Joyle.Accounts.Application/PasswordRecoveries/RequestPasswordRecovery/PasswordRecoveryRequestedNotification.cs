using Joyle.Accounts.Application.PasswordRecoveries.SendPasswordRecoveryEmail;
using Joyle.Accounts.Domain.PasswordRecoveries.Events;
using Joyle.BuildingBlocks.Application.Mediator;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.PasswordRecoveries.RequestPasswordRecovery
{
    public class PasswordRecoveryRequestedNotification : INotificationHandler<PasswordRecoveryRequestedDomainEvent>
    {
        private readonly IMediatorHandler _mediator;

        public PasswordRecoveryRequestedNotification(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(PasswordRecoveryRequestedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.ExecuteCommandAsync(new SendPasswordRecoveryEmailCommand(
                notification.PasswordRecoveryId,
                notification.RecoveryLink,
                notification.Email));
        }
    }
}
