using Joyle.Accounts.Domain.UserRegistrations.Events;
using Joyle.Accounts.Domain.Users;
using Joyle.Accounts.Domain.Users.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.UserRegistrations.ConfirmUserRegistration
{
    public class UserRegistrationConfirmedNotification : INotificationHandler<UserRegistrationConfirmedDomainEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserRegistrationConfirmedNotification(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UserRegistrationConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = User.CreateUserFromRegistration(
                 notification.UserRegistration.Id,
                 notification.UserRegistration.Username,
                 notification.UserRegistration.FullName,
                 notification.UserRegistration.Email,
                 notification.UserRegistration.Password);

            await _userRepository.AddAsync(user);

            await _userRepository.UnitOfWork.Commit();
        }
    }
}
