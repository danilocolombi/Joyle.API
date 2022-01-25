using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Application.Decorators
{
    public class CommandValidationHandlerDecorator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public CommandValidationHandlerDecorator(
          IValidator<TRequest>[] validators)
        {
            this._validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                           .Select(v => v.Validate(request))
                           .SelectMany(result => result.Errors)
                           .Where(error => error != null)
                           .ToList();

            if (failures.Any())
                throw new CommandInvalidException(failures.Select(f => f.ErrorMessage));

            return await next();
        }
    }
}
