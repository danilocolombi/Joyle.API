using FluentValidation;
using Joyle.Accounts.Application.UserRegistrations;

namespace Joyle.Accounts.Application.PasswordRecoveries.RecoverPassword
{
    public class RecoverPasswordCommandValidator : AbstractValidator<RecoverPasswordCommand>
    {
        public RecoverPasswordCommandValidator()
        {
            RuleFor(command => command.Password)
             .Must(HasValidPassword)
             .WithMessage(PasswordValidator.Specifications);
        }

        private static bool HasValidPassword(string password)
          => PasswordValidator.Validate(password);
    }
}
