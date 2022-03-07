using FluentValidation;
using Joyle.Accounts.Application.UserRegistrations;

namespace Joyle.Accounts.Application.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordCommandValidator()
        {
            RuleFor(command => command.NewPassword)
             .Must(HasValidPassword)
             .WithMessage(PasswordValidator.Specifications);
        }

        private static bool HasValidPassword(string password)
            => PasswordValidator.Validate(password);
    }
}
