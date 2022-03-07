using Joyle.Accounts.Domain;
using Joyle.Accounts.Domain.PasswordRecoveries;
using Joyle.Accounts.Domain.PasswordRecoveries.Interfaces;
using Joyle.Accounts.Domain.Users.Interfaces;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.PasswordRecoveries.RequestPasswordRecovery
{
    public class RequestPasswordRecoveryCommandHandler : ICommandHandler<RequestPasswordRecoveryCommand>
    {
        private readonly IPasswordRecoveryRepository _passwordRecoveryRepository;
        private readonly IUserRepository _userRepository;

        public RequestPasswordRecoveryCommandHandler(IPasswordRecoveryRepository passwordRecoveryRepository, IUserRepository userRepository)
        {
            _passwordRecoveryRepository = passwordRecoveryRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RequestPasswordRecoveryCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByEmail(request.Email) == null)
                return Unit.Value;

            var passwordRecovery = PasswordRecovery.Request(new Email(request.Email), request.RecoveryLink);

            await _passwordRecoveryRepository.AddAsync(passwordRecovery);

            await _passwordRecoveryRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
