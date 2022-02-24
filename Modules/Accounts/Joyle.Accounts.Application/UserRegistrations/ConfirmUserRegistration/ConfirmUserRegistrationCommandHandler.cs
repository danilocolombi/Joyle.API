using Joyle.Accounts.Domain.UserRegistrations.Interfaces;
using Joyle.BuildingBlocks.Application;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommandHandler : ICommandHandler<ConfirmUserRegistrationCommand>
    {
        private IUserRegistrationRepository _userRegistrationRepository;

        public ConfirmUserRegistrationCommandHandler(IUserRegistrationRepository userRegistrationRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
        }

        public async Task<Unit> Handle(ConfirmUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = await _userRegistrationRepository.FindAsync(request.RegistrationId);

            if (userRegistration == null)
                throw new CommandInvalidException("Invalid user registration");

            userRegistration.Confirm();

            await _userRegistrationRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
