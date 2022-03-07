using FluentValidation;
using Joyle.Accounts.Domain;
using System;

namespace Joyle.Accounts.Application.PasswordRecoveries.RequestPasswordRecovery
{
    public class RequestPasswordRecoveryCommandValidator : AbstractValidator<RequestPasswordRecoveryCommand>
    {
        public static string RecoveryLinkErrorMessage => "Recovery link is not valid";

        public RequestPasswordRecoveryCommandValidator()
        {
            RuleFor(command => command.Email)
               .Must(HasValidEmail)
               .WithMessage(Email.Specifications);

            RuleFor(command => command.RecoveryLink)
             .Must(HasValidRecoveryLink)
             .WithMessage(RecoveryLinkErrorMessage);
        }
        private static bool HasValidEmail(string email)
            => Email.Validate(email);

        private static bool HasValidRecoveryLink(string confirmationLink)
          => Uri.IsWellFormedUriString(confirmationLink, UriKind.Absolute);
    }
}
