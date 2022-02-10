using Joyle.Accounts.Application.Authentication;
using Joyle.Accounts.Domain;
using Joyle.Accounts.Domain.UserRegistrations;
using Joyle.Accounts.Domain.UserRegistrations.Interfaces;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
    {
        private readonly IUserRegistrationRepository _repository;

        public RegisterNewUserCommandHandler(IUserRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = PasswordManager.HashPassword(request.Password);
            var counterUsersWithThisUsername = await _repository.CountUsersWithUsername(request.Username);

            var userRegistration = UserRegistration.RegisterNewUser(
                new Username(request.Username),
                request.FullName,
                new Email(request.Email),
                hashedPassword,
                counterUsersWithThisUsername,
                request.ConfirmationLink);

            await _repository.AddAsync(userRegistration);

            await _repository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
