using Domain.Validation.Validators;
using MediatR;

namespace Domain.DomainEvents;

/// <summary>
/// Событие, которое генерируется при обновлении количества товара в аптечном пункте.
/// Содержит идентификатор товара и новое количество.
/// </summary>
public class DrugItemUpdatedEvent : INotification
{
    /// <summary>
    /// Конструктор, создающий событие обновления количества товара.
    /// </summary>
    /// <param name="drugItemId">Идентификатор существующего товара (DrugItem).</param>
    /// <param name="newCount">Новое количество товара.</param>
    public DrugItemUpdatedEvent(Guid drugItemId, decimal newCount)
    {
        DrugItemId = drugItemId;
        NewCount = newCount;

        Validate();
    }

    /// <summary>
    /// Идентификатор существующего товарного предмета (DrugItem).
    /// </summary>
    public Guid DrugItemId { get; }

    /// <summary>
    /// Новое количество товара.
    /// </summary>
    public decimal NewCount { get; }

    /// <summary>
    /// Валидирует событие перед его добавлением в систему.
    /// </summary>
    private void Validate()
    {
        var validator = new DrugItemUpdatedEventValidator();
    }
}