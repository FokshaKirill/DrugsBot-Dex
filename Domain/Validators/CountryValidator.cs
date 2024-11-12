using System.Text.RegularExpressions;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()   //Done
    {
        var ruleBuilderOptions = 
            RuleFor(c => c.Name)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Length(2, 100).WithMessage(ValidationMessage.WrongLengthRange)
                .Matches(@"^[a-zа-я\s]+$", RegexOptions.IgnoreCase).WithMessage(ValidationMessage.WrongMatches);

        RuleFor(c => c.Code)
            .Length(2).WithMessage(ValidationMessage.WrongLengthRange)
            .Matches(@"^[A-Z]+$").WithMessage(ValidationMessage.WrongMatches);
    }
}