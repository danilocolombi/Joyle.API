using Joyle.Accounts.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Joyle.Accounts.Infra.Configuration
{
    public class AccountsContextFactory : IDesignTimeDbContextFactory<AccountsContext>
    {
        public AccountsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountsContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JoyleTeste;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AccountsContext(optionsBuilder.Options);
        }
    }
}
