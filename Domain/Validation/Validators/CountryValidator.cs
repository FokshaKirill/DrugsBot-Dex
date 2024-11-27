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
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessages.WrongLengthRange)
            .Matches(RegexPatterns.OnlyLettersAndSpaces, RegexOptions.IgnoreCase)
            .WithMessage(ValidationMessages.WrongMatches);

        RuleFor(c => c.Code)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(2).WithMessage(ValidationMessages.WrongLength)
            .Matches(RegexPatterns.OnlyBigLatinLetters).WithMessage(ValidationMessages.WrongMatches);
    }
}