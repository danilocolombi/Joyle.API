using Joyle.BuildingBlocks.Application.Emails;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.PasswordRecoveries.SendPasswordRecoveryEmail
{
    internal class SendPasswordRecoveryEmailCommandHandler : ICommandHandler<SendPasswordRecoveryEmailCommand>
    {
        private readonly IEmailSender _emailSender;

        public SendPasswordRecoveryEmailCommandHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task<Unit> Handle(SendPasswordRecoveryEmailCommand request, CancellationToken cancellationToken)
        {
            var link = $"<a href=\"{request.RecoveryLink}/{request.PasswordRecoveryId}\">link</a>";
            var content = @$"Hello! You should click in the following link in order to recover your password {link}.<br>
                            You have 24 hours to do this, after that you should start a new request.";

            await _emailSender.Send(new EmailMessage(request.Email.Address, "Joyle - Password Recovery", content));

            return Unit.Value;
        }
    }
}
