using Joyle.BuildingBlocks.Application.Messages;

namespace Joyle.Accounts.Application.Authentication.Authenticate
{
    public class AuthenticateCommand : CommandBase<AuthenticationResult>
    {

        public string Email { get; }
        public string Password { get; }

        public AuthenticateCommand(string login, string password)
        {
            Email = login;
            Password = password;
        }
    }
}
