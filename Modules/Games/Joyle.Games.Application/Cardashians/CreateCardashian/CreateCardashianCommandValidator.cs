using FluentValidation;

namespace Joyle.Games.Application.Cardashians.CreateCardashian
{
    public class CreateCardashianCommandValidator : AbstractValidator<CreateCardashianCommand>
    {
        public static string TitleErrorMessage => "Title is required";
        public static string AuthorErrorMessage => "Author is required";
        public CreateCardashianCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .WithMessage(TitleErrorMessage);

            RuleFor(c => c.AuthorId)
                .NotNull()
                .WithMessage(AuthorErrorMessage);
        }
    }
}
