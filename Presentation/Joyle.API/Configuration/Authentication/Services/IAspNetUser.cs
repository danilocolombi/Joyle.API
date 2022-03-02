using System;

namespace Joyle.API.Configuration.Authentication.Services
{
    public interface IAspNetUser
    {
        string GetEmail();
        Guid GetId();
        string GetToken();
        bool IsAuthenticated();
    }
}
