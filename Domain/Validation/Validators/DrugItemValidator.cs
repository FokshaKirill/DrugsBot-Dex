using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        var ruleBuilderOptions =
            RuleFor(di => di.Cost)
                .GreaterThan(0).WithMessage(ValidationMessages.NegativeNumOrZeroError)
                .PrecisionScale(65, 2, true).WithMessage(ValidationMessages.WrongPrecisionScale);

        RuleFor(di => di.Count)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessages.GreaterThanNumError)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeNumError);

        RuleFor(d => d.DrugId)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.Drug)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.DrugStoreId)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.DrugStore)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}