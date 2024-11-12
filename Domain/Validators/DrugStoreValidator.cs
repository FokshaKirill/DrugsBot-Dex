using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

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
                .GreaterThan(0);

            RuleFor(n => n.Address)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Must(a => a.Street.Length >= 3 && a.Street.Length <= 100).WithMessage(ValidationMessage.WrongLengthRange)
                .Must(a => a.City.Length >= 2 && a.City.Length <= 50).WithMessage(ValidationMessage.WrongLengthRange)
                .Must(a => !string.IsNullOrEmpty(a.PostalCode) && a.PostalCode.All(char.IsDigit) && (a.PostalCode.Length == 5 || a.PostalCode.Length == 6)).WithMessage(ValidationMessage.WrongPostalCode)
                .Must(a => !string.IsNullOrEmpty(a.Country) && a.Country.Length == 2 && a.Country.All(char.IsUpper)).WithMessage(ValidationMessage.WrongCountryCode);
    }
}
