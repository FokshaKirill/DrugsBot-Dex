using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMessage.WrongLengthRange)
            .Matches(RegexPatterns.NoSpecialSymbols).WithMessage(ValidationMessage.SpecialSymbolsError);
        
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLengthRange);

        RuleFor(d => d.Country)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        
        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
    }
}