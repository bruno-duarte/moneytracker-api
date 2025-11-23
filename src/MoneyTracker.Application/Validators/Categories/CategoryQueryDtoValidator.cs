using FluentValidation;
using MoneyTracker.Application.DTOs.Categories;

namespace MoneyTracker.Application.Validators.Categories
{
    public class CategoryQueryDtoValidator : AbstractValidator<CategoryQueryDto>
    {
        public CategoryQueryDtoValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("PageNumber must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("PageSize must be greater than 0.")
                .LessThanOrEqualTo(200)
                .WithMessage("PageSize must be less than or equal to 200.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The category name cannot be empty.")
                .MaximumLength(100).WithMessage("The category name must be at most 100 characters long.");
        }
    }
}
