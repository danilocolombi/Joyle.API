using System;

namespace Joyle.API.Modules.Accounts.Users.Requests
{
    public class ChangeUserPasswordRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
