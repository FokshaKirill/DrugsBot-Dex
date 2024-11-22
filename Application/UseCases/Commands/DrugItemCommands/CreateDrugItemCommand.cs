using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Команда для создания связи препарата и аптеки.
/// </summary>
public class CreateDrugItemCommand : IRequest<DrugItem?>
{
    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; set; }

    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; set; }

    /// <summary>
    /// Стоимость препарата.
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    /// Количество препарата.
    /// </summary>
    public double Count { get; set; }
}