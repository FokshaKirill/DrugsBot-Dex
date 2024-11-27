using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        var ruleBuilderOptions =
            RuleFor(dn => dn.DrugNetwork)
                .NotNull().WithMessage(ValidationMessages.NotNull)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .Length(2, 100).WithMessage(ValidationMessages.WrongLengthRange);

        RuleFor(dn => dn.Number)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessages.NegativeNumOrZeroError);

        RuleFor(n => n.Address)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}