using FluentValidation;

namespace Joyle.Games.Application.Cardashians.AddCardashianCard
{
    public class AddCardashianCardCommandValidator : AbstractValidator<AddCardashianCardCommand>
    {
        public static string DescriptionErrorMessage => "Description is required";
        public static string CardashianErrorMessage => "Cardashian is required";

        public AddCardashianCardCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage(DescriptionErrorMessage);

            RuleFor(c => c.CardashianId)
                .NotNull()
                .WithMessage(CardashianErrorMessage);
        }
    }
}
