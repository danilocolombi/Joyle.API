using Joyle.BuildingBlocks.Domain;
using System;
using System.Threading.Tasks;

namespace Joyle.Accounts.Domain.Users.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user);
        Task<User> FindAsync(Guid userId);
        Task<User> GetUserByEmail(string email);
        Task<int> CountUsersWithUsername(string username);
    }
}
