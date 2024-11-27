using Domain.DomainEvents;
using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class CountryUpdatedEventValidator : AbstractValidator<CountryUpdatedEvent>
{
    public CountryUpdatedEventValidator()
    {
        RuleFor(x => x.PreviousValue)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
        RuleFor(x => x.UpdatedValue)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);

        RuleFor(x => x.UpdatedValue)
            .Must(BeAValidCountryCode)
            .WithMessage(ValidationMessages.WrongCountryCode);
    }

    private bool BeAValidCountryCode(string code)
    {
        return Country.ValidCountryCodes.Contains(code);
    }
}