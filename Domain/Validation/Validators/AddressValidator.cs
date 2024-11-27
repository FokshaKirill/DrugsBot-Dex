using Domain.Validators;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validation.Validators;

public sealed class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        // Валидация для City
        RuleFor(a => a.City)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(2, 50).WithMessage(ValidationMessages.WrongLengthRange)
            .Matches(RegexPatterns.OnlyLetters).WithMessage(ValidationMessages.SpecialSymbolsError);

        // Валидация для Street
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(3, 100).WithMessage(ValidationMessages.WrongLengthRange)
            .Matches(RegexPatterns.OnlyLetters).WithMessage(ValidationMessages.OnlyLettersError);

        // Валидация для House
        RuleFor(a => a.House)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessages.LessThanNumError);

        RuleFor(p => p.PostalCode)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .InclusiveBetween(10000, 999999).WithMessage(ValidationMessages.InclusiveBetweenError);
    }
}