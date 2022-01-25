using Joyle.BuildingBlocks.Application.Messages;
using Joyle.BuildingBlocks.Domain;
using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Application.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventAsync<T>(T evento) where T : IEvent;
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
