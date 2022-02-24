using Joyle.Accounts.Domain.Users;
using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Joyle.Accounts.Infra.Data.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountsContext _context;

        public UserRepository(AccountsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task<int> CountUsersWithUsername(string username)
        {
            return await _context.UserRegistrations
                          .CountAsync(ur => ur.Username.Value == username);
        }
    }
}
