using Joyle.BuildingBlocks.Domain;
using System;
using System.Threading.Tasks;

namespace Joyle.Accounts.Domain.PasswordRecoveries.Interfaces
{
    public interface IPasswordRecoveryRepository : IRepository<PasswordRecovery>
    {
        Task AddAsync(PasswordRecovery passwordRecovery);
        Task<PasswordRecovery> FindAsync(Guid id);
    }
}
