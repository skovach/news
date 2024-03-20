using FluentValidation;

namespace News.Application.Dto.Validators;

public class ArticleUpdateDtoValidator : AbstractValidator<ArticleDto>
{
    public ArticleUpdateDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(2, 250).WithMessage("Title must be between 2 and 250 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
    }
}