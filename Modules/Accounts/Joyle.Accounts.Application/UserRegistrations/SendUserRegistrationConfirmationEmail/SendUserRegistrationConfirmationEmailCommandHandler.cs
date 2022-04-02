using Joyle.BuildingBlocks.Application.Emails;
using Joyle.BuildingBlocks.Application.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    internal class SendUserRegistrationConfirmationEmailCommandHandler : ICommandHandler<SendUserRegistrationConfirmationEmailCommand>
    {
        private readonly IEmailSender _emailSender;

        public SendUserRegistrationConfirmationEmailCommandHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task<Unit> Handle(SendUserRegistrationConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
            var link = $"<a href=\"{request.ConfirmationLink}/{request.UserRegistrationId}\">link</a>";
            var content = $"You're almost there, By clicking on the following link, you are confirming your email address.: {link}.";

            await _emailSender.Send(new EmailMessage(request.Email.Address, "Welcome to Joyle!", content));

            return Unit.Value;
        }
    }
}
