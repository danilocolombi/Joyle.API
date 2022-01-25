using MediatR;

namespace Joyle.BuildingBlocks.Application.Messages
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
