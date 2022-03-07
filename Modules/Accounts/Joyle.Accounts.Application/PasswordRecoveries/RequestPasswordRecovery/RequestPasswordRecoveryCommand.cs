using Joyle.BuildingBlocks.Application.Messages;

namespace Joyle.Accounts.Application.PasswordRecoveries.RequestPasswordRecovery
{
    public class RequestPasswordRecoveryCommand : CommandBase
    {
        public string Email { get; }
        public string RecoveryLink { get; }

        public RequestPasswordRecoveryCommand(string email, string recoveryLink)
        {
            Email = email;
            RecoveryLink = recoveryLink;
        }
    }
}
