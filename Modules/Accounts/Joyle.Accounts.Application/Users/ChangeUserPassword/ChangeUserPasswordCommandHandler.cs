using Joyle.Accounts.Application.Authentication;
using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : ICommandHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(request.UserId);

            if (user == null)
                throw new CommandInvalidException("Invalid user");

            if (!PasswordManager.VerifyHashedPassword(user.Password, request.CurrentPassword))
                throw new CommandInvalidException("Current password is wrong");

            var newHashedPassword = PasswordManager.HashPassword(request.NewPassword);

            user.ResetPassword(newHashedPassword);

            await _userRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
