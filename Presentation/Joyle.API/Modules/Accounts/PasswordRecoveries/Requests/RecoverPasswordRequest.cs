using System;

namespace Joyle.API.Modules.Accounts.PasswordRecoveries.Requests
{
    public class RecoverPasswordRequest
    {
        public Guid PasswordRecoveryId { get; set; }
        public string Password { get; set; }
    }
}
