using Joyle.BuildingBlocks.Application.Messages;

namespace Joyle.Accounts.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommand : CommandBase
    {
        public string Username { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Password { get; }
        public string ConfirmationLink { get; }

        public RegisterNewUserCommand(string userName, string fullName, string email, string password, string confirmationLink)
        {
            Username = userName;
            FullName = fullName;
            Email = email;
            Password = password;
            ConfirmationLink = confirmationLink;
        }
    }
}
