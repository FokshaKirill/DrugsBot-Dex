using Domain.Entities;
using Domain.Interfaces;
using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.DomainEvents;

/// <summary>
/// Событие, которое генерируется при обновлении информации о стране.
/// Содержит старое и новое значение информации (например, старое/новое название или код).
/// </summary>
public class CountryUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Конструктор, создающий событие обновления информации о стране.
    /// </summary>
    /// <param name="country">Обновляемая страна.</param>
    /// <param name="previousValue">Старое значение (например, старое название или код).</param>
    /// <param name="updatedValue">Новое значение (например, новое название или код).</param>
    public CountryUpdatedEvent(Country country, string previousValue, string updatedValue)
    {
        Country = country;
        CountryId = country.Id;
        PreviousValue = previousValue;
        UpdatedValue = updatedValue;

        Validate();
    }

    /// <summary>
    /// Идентификатор страны, для которой было произведено обновление.
    /// </summary>
    public Guid CountryId { get; }

    /// <summary>
    /// Старое значение (например, старое название или код).
    /// </summary>
    public string PreviousValue { get; }

    /// <summary>
    /// Новое значение (например, новое название или код).
    /// </summary>
    public string UpdatedValue { get; }

    /// <summary>
    /// Объект страны, для которой произошло обновление.
    /// </summary>
    public Country Country { get; }

    /// <summary>
    /// Валидирует событие перед его добавлением в систему.
    /// </summary>
    private void Validate()
    {
        var validator = new CountryUpdatedEventValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}