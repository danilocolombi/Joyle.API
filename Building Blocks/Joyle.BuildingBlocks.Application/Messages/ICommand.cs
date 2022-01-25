using MediatR;
using System;

namespace Joyle.BuildingBlocks.Application.Messages
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
        public DateTime OcurredOn { get; }
    }

    public interface ICommand : IRequest
    {
        Guid Id { get; }
        public DateTime OcurredOn { get; }
    }
}
