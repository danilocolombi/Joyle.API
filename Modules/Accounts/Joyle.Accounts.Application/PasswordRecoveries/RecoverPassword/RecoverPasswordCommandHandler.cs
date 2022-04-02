using Joyle.Accounts.Application.Authentication;
using Joyle.Accounts.Domain.PasswordRecoveries.Interfaces;
using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.PasswordRecoveries.RecoverPassword
{
    internal class RecoverPasswordCommandHandler : ICommandHandler<RecoverPasswordCommand>
    {
        private readonly IPasswordRecoveryRepository _passwordRecoveryRepository;

        public RecoverPasswordCommandHandler(IPasswordRecoveryRepository passwordRecoveryRepository)
        {
            _passwordRecoveryRepository = passwordRecoveryRepository;
        }

        public async Task<Unit> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
        {
            var passwordRecovery = await _passwordRecoveryRepository.FindAsync(request.PasswordRecoveryId);

            if (passwordRecovery == null)
                throw new CommandInvalidException("Invalid password recovery");

            var hashedPassword = PasswordManager.HashPassword(request.Password);

            passwordRecovery.Recover(hashedPassword);

            await _passwordRecoveryRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
