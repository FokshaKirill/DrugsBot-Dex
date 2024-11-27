using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        var ruleBuilderOptions =
            RuleFor(p => p.ExternalId)
                .NotNull().WithMessage(ValidationMessages.NotNull)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(p => p.Email)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}