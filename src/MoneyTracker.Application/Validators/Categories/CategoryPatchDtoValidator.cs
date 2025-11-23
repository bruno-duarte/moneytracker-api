using FluentValidation;
using MoneyTracker.Application.DTOs.Categories;

namespace MoneyTracker.Application.Validators.Categories
{
    public class CategoryPatchDtoValidator : AbstractValidator<CategoryPatchDto>
    {
        public CategoryPatchDtoValidator()
        {
            When(x => x.Name != null, () =>
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("The category name cannot be empty.")
                    .MaximumLength(100).WithMessage("The category name must be at most 100 characters long.");
            });
        }
    }
}
