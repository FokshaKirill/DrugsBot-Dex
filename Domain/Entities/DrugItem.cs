using Domain.Events;
using Domain.Validation.Validators;

namespace Domain.Entities;

/// <summary>
/// Связь между препаратом и аптекой
/// </summary>
public class DrugItem : BaseEntity<DrugItem>
{
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, double count, Drug drug, DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;

        // Вызов валидации через базовый класс
        ValidateEntity(new DrugItemValidator());
    }

    #region Свойства

    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }

    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; private set; }

    /// <summary>
    /// Стоимость препарата в данной аптеке.
    /// </summary>
    public decimal Cost { get; private set; }

    /// <summary>
    /// Количество препарата на складе.
    /// </summary>
    public double Count { get; private set; }

    // Навигационные свойства
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }

    #endregion

    #region Методы

    /// <summary>
    /// Обновить стоимость препарата.
    /// </summary>
    /// <param name="cost">Новая стоимость</param>
    public void UpdateCost(decimal cost)
    {
        if (cost <= 0)
            throw new ArgumentException("Cost must be greater than zero.", nameof(cost));

        Cost = cost;

        ValidateEntity(new DrugItemValidator());

        AddDomainEvent(new DrugItemUpdatedEvent());
    }

    /// <summary>
    /// Обновить количество препарата на складе.
    /// </summary>
    /// <param name="count">Новое количество</param>
    public void UpdateCount(double count)
    {
        if (count < 0)
            throw new ArgumentException("Count cannot be negative.", nameof(count));

        Count = count;

        ValidateEntity(new DrugItemValidator());

        AddDomainEvent(new DrugItemUpdatedEvent());
    }

    /// <summary>
    /// Обновить связь с препаратом.
    /// </summary>
    /// <param name="drug">Новый объект препарата</param>
    public void UpdateDrug(Drug drug)
    {
        Drug = drug ?? throw new ArgumentNullException(nameof(drug));

        ValidateEntity(new DrugItemValidator());

        AddDomainEvent(new DrugItemUpdatedEvent());
    }

    /// <summary>
    /// Обновить связь с аптекой.
    /// </summary>
    /// <param name="drugStore">Новый объект аптеки</param>
    public void UpdateDrugStore(DrugStore drugStore)
    {
        DrugStore = drugStore ?? throw new ArgumentNullException(nameof(drugStore));

        ValidateEntity(new DrugItemValidator());

        AddDomainEvent(new DrugItemUpdatedEvent());
    }

    #endregion
}