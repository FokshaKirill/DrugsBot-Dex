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
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLengthRange);
            
            RuleFor(dn => dn.Number)
                .GreaterThan(0).WithMessage(ValidationMessage.NegativeNumOrZeroError);

            RuleFor(n => n.Address)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Must(a => a.Street.Length >= 3 && a.Street.Length <= 100)
                .WithMessage(ValidationMessage.WrongLengthRange)
                .Must(a => a.City.Length >= 2 && a.City.Length <= 50).WithMessage(ValidationMessage.WrongLengthRange);
    }
}
