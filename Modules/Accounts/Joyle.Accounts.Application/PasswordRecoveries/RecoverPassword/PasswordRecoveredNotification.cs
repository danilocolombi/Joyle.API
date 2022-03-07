using Joyle.Accounts.Domain.PasswordRecoveries.Events;
using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Application;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.PasswordRecoveries.RecoverPassword
{
    public class PasswordRecoveredNotification : INotificationHandler<PasswordRecoveredDomainEvent>
    {
        private readonly IUserRepository _userRepository;

        public PasswordRecoveredNotification(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(PasswordRecoveredDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(notification.Email.Address);

            if (user == null)
                throw new CommandInvalidException("Invalid user");

            user.ResetPassword(notification.Password);

            await _userRepository.UnitOfWork.Commit();
        }
    }
}
