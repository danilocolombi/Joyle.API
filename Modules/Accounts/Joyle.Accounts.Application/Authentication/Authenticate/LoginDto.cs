using System;

namespace Joyle.Accounts.Application.Authentication.Authenticate
{
    public class LoginDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
