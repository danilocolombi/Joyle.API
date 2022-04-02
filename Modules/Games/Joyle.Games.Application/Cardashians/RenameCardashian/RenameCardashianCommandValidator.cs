using FluentValidation;

namespace Joyle.Games.Application.Cardashians.RenameCardashian
{
    public class RenameCardashianCommandValidator : AbstractValidator<RenameCardashianCommand>
    {
        public static string TitleErrorMessage => "Title is required";

        public RenameCardashianCommandValidator()
        {
            RuleFor(c => c.Title)
             .NotEmpty()
             .WithMessage(TitleErrorMessage);
        }
    }
}
