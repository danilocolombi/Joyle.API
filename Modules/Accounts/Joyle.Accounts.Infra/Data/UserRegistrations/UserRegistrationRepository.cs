using Joyle.Accounts.Domain.UserRegistrations;
using Joyle.Accounts.Domain.UserRegistrations.Interfaces;
using Joyle.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Joyle.Accounts.Infra.Data.UserRegistrations
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly AccountsContext _context;

        public UserRegistrationRepository(AccountsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(UserRegistration userRegistration)
        {
            await _context.UserRegistrations.AddAsync(userRegistration);
        }

        public async Task<UserRegistration> FindAsync(Guid userRegistrationId)
        {
            return await _context.UserRegistrations.FindAsync(userRegistrationId);
        }

        public async Task<int> CountUsersWithUsername(string username)
        {
            return await _context.UserRegistrations
                          .CountAsync(ur => ur.Username.Value == username);
        }
    }
}
