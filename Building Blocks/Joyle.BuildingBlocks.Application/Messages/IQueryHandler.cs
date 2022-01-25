using MediatR;

namespace Joyle.BuildingBlocks.Application.Messages
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
    public interface IQueryHandler<TResult>
    {
    }
}
