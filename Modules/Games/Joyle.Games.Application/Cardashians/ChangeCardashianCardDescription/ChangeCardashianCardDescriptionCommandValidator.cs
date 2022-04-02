using FluentValidation;

namespace Joyle.Games.Application.Cardashians.ChangeCardashianCardDescription
{
    public class ChangeCardashianCardDescriptionCommandValidator : AbstractValidator<ChangeCardashianCardDescriptionCommand>
    {
        public static string DescriptionErrorMessage => "Description is required";

        public ChangeCardashianCardDescriptionCommandValidator()
        {
            RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage(DescriptionErrorMessage);
        }
    }
}
