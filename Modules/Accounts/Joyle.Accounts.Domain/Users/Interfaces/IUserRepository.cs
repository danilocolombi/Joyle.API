using Joyle.BuildingBlocks.Domain;
using System.Threading.Tasks;

namespace Joyle.Accounts.Domain.Users.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user);
        Task<int> CountUsersWithUsername(string username);
    }
}
