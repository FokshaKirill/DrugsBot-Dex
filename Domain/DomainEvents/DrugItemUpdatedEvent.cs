using Domain.Validation.Validators;
using FluentValidation;
using MediatR;

namespace Domain.DomainEvents;

public class DrugItemUpdatedEvent : INotification
{
    /// <param name="drugItemId">Идентификатор существующего DrugItem.</param>
    /// <param name="newCount">Новое количество товара.</param>
    public DrugItemUpdatedEvent(Guid drugItemId, decimal newCount)
    {
        DrugItemId = drugItemId;
        NewCount = newCount;

        Validate();
    }

    /// <summary>
    /// Идентификатор существующего DrugItem
    /// </summary>
    public Guid DrugItemId { get; }

    /// <summary>
    /// Новое количество товара 
    /// </summary>
    public decimal NewCount { get; }

    private void Validate()
    {
        var validator = new DrugItemUpdatedEventValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}