using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMessages.WrongLengthRange)
            .Matches(RegexPatterns.NoSpecialSymbols).WithMessage(ValidationMessages.SpecialSymbolsError);

        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessages.WrongLengthRange);

        RuleFor(d => d.Country)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}