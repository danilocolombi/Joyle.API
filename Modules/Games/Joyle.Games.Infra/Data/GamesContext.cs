using Joyle.BuildingBlocks.Application.Mediator;
using Joyle.BuildingBlocks.Domain;
using Joyle.BuildingBlocks.Infra.Extensions;
using Joyle.Games.Domain.Cardashians;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Joyle.Games.Infra.Data
{
    public class GamesContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public GamesContext(DbContextOptions<GamesContext> options) : base(options) { }

        public GamesContext(DbContextOptions<GamesContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Cardashian> Cardashians { get; set; }

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
