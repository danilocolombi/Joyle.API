using System.Threading.Tasks;

namespace Joyle.Accounts.Domain.UserRegistrations.Interfaces
{
    public interface IUserRegistrationRepository
    {
        Task AdicionarAsync(UserRegistration userRegistration);
        Task<int> CountUsersWithUsername(string username);
    }
}
