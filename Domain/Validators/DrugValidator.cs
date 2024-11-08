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
            .Length(2, 150).WithMessage(ValidationMessage.WrongLength);
            
            RuleFor(d => d.CountryCodeId)
            .Length(2)
            .Matches(@"^[a-z\s]+$", RegexOptions.IgnoreCase);
    }
}
public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()   //Done
    {
        var ruleBuilderOptions = 
            RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zа-я\s]+$").WithMessage(ValidationMessage.WrongMatches);
        
            RuleFor(c => c.Code)
            .Length(2).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-ZА-Я]+$").WithMessage(ValidationMessage.WrongMatches);
    }
}
public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        var ruleBuilderOptions = 
            RuleFor(di => di.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.NotGreaterThanNum)
            .PrecisionScale(65, 2, true).WithMessage(ValidationMessage.WrongPrecisionScale);

        RuleFor(di => di.Count)
            .LessThanOrEqualTo(10000)
            .GreaterThanOrEqualTo(0);   //TODO: Целое неотрицательное число
    }
}
public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        var ruleBuilderOptions = 
            RuleFor(dn => dn.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength);
            
            RuleFor(dn => dn.Number)
                .GreaterThan(0);   //TODO: Целое положительное число
                                   //TODO: уникально в пределах сети аптек

            RuleFor(n => n.Address)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Must(a => a.Street.Length >= 3 && a.Street.Length <= 100).WithMessage(ValidationMessage.WrongLength)
                .Must(a => a.City.Length >= 2 && a.City.Length <= 50).WithMessage(ValidationMessage.WrongLength);
                // .Must(a => a.)

            // RuleFor(n => n.Address.Street)
            // Utrom sdelayu. Proverka GitHub'a
    }
}