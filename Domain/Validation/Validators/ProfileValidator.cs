using Domain.Entities;
using FluentValidation;
using Domain.Validators;

namespace Domain.Validation.Validators;

public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        var ruleBuilderOptions =
            RuleFor(p => p.ExternalId)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        
            RuleFor(p => p.Email)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

    }
}