using Joyle.Accounts.Domain;
using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.Users.ChangeUsername
{
    public class ChangeUsernameCommandHandler : ICommandHandler<ChangeUsernameCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUsernameCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.UserId);

            if (user == null)
                throw new CommandInvalidException("Invalid user");

            var counterUsersWithThisUsername = await _userRepository.CountUsersWithUsername(request.Username);

            user.ChangeUsername(new Username(request.Username), counterUsersWithThisUsername);

            await _userRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
