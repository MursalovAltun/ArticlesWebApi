using FluentValidation;

namespace Common.DTO.Validations
{
    public class ArticleAddValidation : AbstractValidator<ArticleAddDTO>
    {
        public ArticleAddValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}