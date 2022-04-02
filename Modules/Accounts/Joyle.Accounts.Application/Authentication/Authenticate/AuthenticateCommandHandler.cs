using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Application.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.Authentication.Authenticate
{
    internal class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        private IUserRepository _userRepository;

        public AuthenticateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);

            if (user == null)
                return new AuthenticationResult("Incorrect login or password");

            if (!PasswordManager.VerifyHashedPassword(user.Password, request.Password))
                return new AuthenticationResult("Incorrect login or password");

            if (!user.IsActive)
                return new AuthenticationResult("User is not active");

            var authenticationResult = new AuthenticationResult(new LoginDto
            {
                Email = user.Email.Address,
                Username = user.Username.Value,
                IsActive = user.IsActive,
                Id = user.Id
            });

            return authenticationResult;
        }
    }
}
