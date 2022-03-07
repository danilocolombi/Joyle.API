using Joyle.Accounts.Domain.PasswordRecoveries;
using Joyle.Accounts.Domain.PasswordRecoveries.Interfaces;
using Joyle.BuildingBlocks.Domain;
using System;
using System.Threading.Tasks;

namespace Joyle.Accounts.Infra.Data.PasswordRecoveries
{
    public class PasswordRecoveryRepository : IPasswordRecoveryRepository
    {
        private readonly AccountsContext _context;

        public PasswordRecoveryRepository(AccountsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(PasswordRecovery passwordRecovery)
        {
            await _context.PasswordRecoveries.AddAsync(passwordRecovery);
        }

        public async Task<PasswordRecovery> FindAsync(Guid id)
        {
            return await _context.PasswordRecoveries.FindAsync(id);
        }
    }
}
