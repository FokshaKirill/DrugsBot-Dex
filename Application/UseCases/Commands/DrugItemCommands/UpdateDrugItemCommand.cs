using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Команда для обновления связи препарата и аптеки.
/// </summary>
public class UpdateDrugItemCommand : IRequest<DrugItem?>
{
    /// <summary>
    /// Идентификатор связи препарата и аптеки.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Новая стоимость препарата в аптеке.
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Новое количество препарата в аптеке.
    /// </summary>
    public double? Count { get; set; }
}