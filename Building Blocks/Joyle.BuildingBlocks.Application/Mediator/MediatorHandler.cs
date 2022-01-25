using Joyle.BuildingBlocks.Application.Messages;
using Joyle.BuildingBlocks.Domain;
using MediatR;
using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Application.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await _mediator.Send(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }

        public async Task PublishEventAsync<T>(T evento) where T : IEvent
        {
            await _mediator.Publish(evento);
        }
    }
}
