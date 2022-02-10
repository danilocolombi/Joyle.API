using Joyle.BuildingBlocks.Domain;
using System.Threading.Tasks;

namespace Joyle.Accounts.Domain.UserRegistrations.Interfaces
{
    public interface IUserRegistrationRepository : IRepository<UserRegistration>
    {
        Task AddAsync(UserRegistration userRegistration);
        Task<int> CountUsersWithUsername(string username);
    }
}
