using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        var ruleBuilderOptions =
            RuleFor(d => d.Name)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Length(2, 150).WithMessage(ValidationMessage.WrongLengthRange)
                .Matches(RegexPatterns.NoSpecialSymbols).WithMessage(ValidationMessage.SpecialSymbolsError);
            
        RuleFor(m => m.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLengthRange)                
            .Matches(RegexPatterns.OnlyLettersSpacesDashes).WithMessage(ValidationMessage.SpecialSymbolsError);

        
        RuleFor(d => d.CountryCodeId)
            .Length(2).WithMessage(ValidationMessage.WrongLength)
            .Matches(RegexPatterns.OnlyBigLatinLetters).WithMessage(ValidationMessage.WrongMatches);
    }
}