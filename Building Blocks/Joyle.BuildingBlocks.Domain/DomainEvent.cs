using System;

namespace Joyle.BuildingBlocks.Domain
{
    public class DomainEvent : IEvent
    {
        public Guid Id { get; }
        public DateTime OcurredOn { get; }

        protected DomainEvent()
        {
            this.OcurredOn = DateTime.UtcNow;
            this.Id = Guid.NewGuid();
        }
    }
}
