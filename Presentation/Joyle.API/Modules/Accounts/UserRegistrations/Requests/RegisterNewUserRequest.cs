namespace Joyle.API.Modules.Accounts.UserRegistrations.Requests
{
    public class RegisterNewUserRequest
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationLink { get; set; }
    }
}
