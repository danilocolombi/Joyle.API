using Joyle.BuildingBlocks.Application.Mediator;
using Joyle.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Infra.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.domainEvents != null && x.Entity.domainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.domainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEventAsync(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
