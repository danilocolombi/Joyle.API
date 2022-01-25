using MediatR;
using System;

namespace Joyle.BuildingBlocks.Domain
{
    public interface IEvent : INotification
    {
        public Guid Id { get; }
        public DateTime OcurredOn { get; }
    }
}
