using FluentValidation;
using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Validation.Validators;

public sealed class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        // Валидация для City
        RuleFor(a => a.City)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLengthRange)
            .Matches(RegexPatterns.OnlyLetters).WithMessage(ValidationMessage.SpecialSymbolsError);

        // Валидация для Street
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLengthRange)
            .Matches(RegexPatterns.OnlyLetters).WithMessage(ValidationMessage.SpecialSymbolsError);

        // Валидация для House
        RuleFor(a => a.House)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .LessThanOrEqualTo(10).WithMessage(ValidationMessage.LessThanNumError);
    }
}