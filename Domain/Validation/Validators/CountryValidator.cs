using System.Text.RegularExpressions;
using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLengthRange)
            .Matches(RegexPatterns.OnlyLettersAndSpaces, RegexOptions.IgnoreCase)
            .WithMessage(ValidationMessage.WrongMatches);

        RuleFor(c => c.Code)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2).WithMessage(ValidationMessage.WrongLength)
            .Matches(RegexPatterns.OnlyBigLatinLetters).WithMessage(ValidationMessage.WrongMatches);
    }
}