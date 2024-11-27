using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class FavoriteDrugValidator : AbstractValidator<FavoriteDrug>
{
    public FavoriteDrugValidator()
    {
        var ruleBuilderOptions =
            RuleFor(d => d.Drug)
                .NotNull().WithMessage(ValidationMessages.NotNull)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.DrugId)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.Profile)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.ProfileId)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}