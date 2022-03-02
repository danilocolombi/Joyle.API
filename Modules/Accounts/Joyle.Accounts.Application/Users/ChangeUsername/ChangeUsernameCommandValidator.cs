using FluentValidation;
using Joyle.Accounts.Domain;

namespace Joyle.Accounts.Application.Users.ChangeUsername
{
    public class ChangeUsernameCommandValidator : AbstractValidator<ChangeUsernameCommand>
    {
        public ChangeUsernameCommandValidator()
        {
            RuleFor(command => command.Username)
               .Must(HasValidUsername)
               .WithMessage(Username.Specifications);
        }
        private static bool HasValidUsername(string username)
            => Username.Validate(username);
    }
}
