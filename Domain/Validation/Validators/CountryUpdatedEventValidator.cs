using Domain.DomainEvents;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validation.Validators;

public class CountryUpdatedEventValidator : AbstractValidator<CountryUpdatedEvent>
{
    public CountryUpdatedEventValidator()
    {
        RuleFor(x => x.PreviousValue)
            .NotEmpty().WithMessage("Предыдущее значение не может быть пустым.");
        RuleFor(x => x.UpdatedValue)
            .NotEmpty().WithMessage("Новое значение не может быть пустым.");

        RuleFor(x => x.UpdatedValue)
            .Must(BeAValidCountryCode)
            .WithMessage("Неверный код страны.");
    }

    private bool BeAValidCountryCode(string code)
    {
        return Country.ValidCountryCodes.Contains(code);
    }
}