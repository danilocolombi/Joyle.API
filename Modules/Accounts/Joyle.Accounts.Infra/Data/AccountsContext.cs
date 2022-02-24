using Joyle.Accounts.Domain.UserRegistrations;
using Joyle.Accounts.Domain.Users;
using Joyle.BuildingBlocks.Application.Mediator;
using Joyle.BuildingBlocks.Domain;
using Joyle.BuildingBlocks.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Joyle.Accounts.Infra.Data
{
    public class AccountsContext: DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options) { }

        public AccountsContext(DbContextOptions<AccountsContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<UserRegistration> UserRegistrations { get; set;  }
        public DbSet<User> Users { get; set;  }

        public async Task<bool> Commit()
        {
            try
            {
                await _mediatorHandler.PublishEventsAsync(this);

                await base.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
