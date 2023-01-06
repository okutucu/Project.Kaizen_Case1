using FluentValidation;
using Project.WebAPI.DTOs;

namespace Project.WebAPI.Validations
{
    public class CreateCodeValidator : AbstractValidator<CreateCodeDto>
    {
        public CreateCodeValidator()
        {
            RuleFor(c => c.Length).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(c => c.CharacterSet).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(c => c.Count).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
