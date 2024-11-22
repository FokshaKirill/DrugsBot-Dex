using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Команда для обновления связи препарата и аптеки.
/// </summary>
public class UpdateDrugItemCommand : IRequest<DrugItem?>
{
    public Guid Id { get; set; }
    public decimal? Cost { get; set; }
    public double? Count { get; set; }
}