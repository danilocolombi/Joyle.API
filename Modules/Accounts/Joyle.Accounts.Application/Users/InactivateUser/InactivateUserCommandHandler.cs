using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.Users.InactivateUser
{
    public class InactivateUserCommandHandler : ICommandHandler<InactivateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public InactivateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(InactivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.UserId);

            if (user == null)
                throw new CommandInvalidException("Invalid user");

            user.Inactivate();

            await _userRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
