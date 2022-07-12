using FluentValidation;

namespace Joyle.Accounts.Application.Users.RenameUser
{
    public class RenameUserCommandValidator : AbstractValidator<RenameUserCommand>
    {
        public static string FullNameErrorMessage => "Full name is required";

        public RenameUserCommandValidator()
        {
            RuleFor(command => command.FullName)
                .NotEmpty()
                .WithMessage(FullNameErrorMessage);
        }
    }
}
