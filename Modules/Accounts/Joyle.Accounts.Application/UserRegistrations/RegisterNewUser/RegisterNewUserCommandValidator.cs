using FluentValidation;
using Joyle.Accounts.Domain;
using System;

namespace Joyle.Accounts.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandValidator : AbstractValidator<RegisterNewUserCommand>
    {
        public static string FullNameErrorMessage => "Full name is required";
        public static string ConfirmationLinkErrorMessage => "Confirmation link is not valid";

        public RegisterNewUserCommandValidator()
        {
            RuleFor(command => command.Username)
                .Must(HasValidUsername)
                .WithMessage(Username.Specifications);

            RuleFor(command => command.Email)
                .Must(HasValidEmail)
                .WithMessage(Email.Specifications);

            RuleFor(command => command.FullName)
                .NotEmpty()
                .WithMessage(FullNameErrorMessage);

            RuleFor(command => command.Password)
               .Must(HasValidPassword)
               .WithMessage(PasswordValidator.Specifications);

            RuleFor(command => command.ConfirmationLink)
              .Must(HasValidConfirmationLink)
              .WithMessage(ConfirmationLinkErrorMessage);
        }

        private static bool HasValidUsername(string username)
            => Username.Validate(username);

        private static bool HasValidEmail(string email)
            => Email.Validate(email);

        private static bool HasValidPassword(string password)
            => PasswordValidator.Validate(password);

        private static bool HasValidConfirmationLink(string confirmationLink)
            => Uri.IsWellFormedUriString(confirmationLink, UriKind.Absolute);

    }
}
