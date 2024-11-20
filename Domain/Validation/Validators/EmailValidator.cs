using Domain.Entities;
using Domain.Validators;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validation.Validators;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        var ruleBuilderOptions =
            RuleFor(e => e.Value)
                .Matches(RegexPatterns.EmailPattern).WithMessage(ValidationMessage.EmailError)
                .Length(1, 255).WithMessage(ValidationMessage.WrongLengthRange);
    }
}