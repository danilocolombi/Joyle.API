using Joyle.Accounts.Application.Authentication.Authenticate;

namespace Joyle.API.Configuration.Authentication.Services
{
    public interface IJwtTokenGeneratorService
    {
        string Generate(LoginDto user);
    }
}
