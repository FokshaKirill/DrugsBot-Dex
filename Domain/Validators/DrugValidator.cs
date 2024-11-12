using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        var ruleBuilderOptions =
            RuleFor(d => d.Name)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Length(2, 150).WithMessage(ValidationMessage.WrongLengthRange)
                .Matches("^[a-zа-я0-9]+$").WithMessage(ValidationMessage.SpecialSymbolsError);
            
        RuleFor(m => m.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLengthRange)                
            .Matches(@"^[a-zа-я\s\-]+$").WithMessage(ValidationMessage.SpecialSymbolsError);

        
        RuleFor(d => d.CountryCodeId)
            .Length(2).WithMessage(ValidationMessage.WrongLength)
            .Must(c => Country.ValidCountryCodes.Contains(c))
            .Matches(@"^[A-Z]+$").WithMessage(ValidationMessage.WrongMatches);
    }
}