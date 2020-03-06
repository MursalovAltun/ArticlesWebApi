using FluentValidation;

namespace Common.DTO.Validations
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddDTO>
    {
        public CategoryAddValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}