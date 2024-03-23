using FluentValidation;

namespace News.Application.Dto.Validators;

public class ArticleDtoValidator : AbstractValidator<ArticleDto>
{
    public ArticleDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(2, 250).WithMessage("Title must be between 2 and 250 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.AuthorName)
            .NotEmpty().WithMessage("Author Name is required.");
        
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.");
        
        RuleFor(x => x.ImageFile)
            .NotEmpty().WithMessage("Image is required.");
        
    }
}