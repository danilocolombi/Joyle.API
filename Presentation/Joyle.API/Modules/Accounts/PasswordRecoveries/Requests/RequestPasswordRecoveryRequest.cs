namespace Joyle.API.Modules.Accounts.PasswordRecoveries.Requests
{
    public class RequestPasswordRecoveryRequest
    {
        public string Email { get; set; }
        public string RecoveryLink { get; set; }
    }
}
