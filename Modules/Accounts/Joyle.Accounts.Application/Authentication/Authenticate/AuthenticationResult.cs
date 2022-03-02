namespace Joyle.Accounts.Application.Authentication.Authenticate
{
    public class AuthenticationResult
    {
        public bool Success { get; }

        public string AuthenticationError { get; }

        public LoginDto User { get; }

        public AuthenticationResult(string authenticationError)
        {
            Success = false;
            this.AuthenticationError = authenticationError;
        }

        public AuthenticationResult(LoginDto user)
        {
            this.Success = true;
            this.User = user;
        }
    }
}
