using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Команда для обновления связи препарата и аптеки.
/// </summary>
public record UpdateDrugItemCommand(Guid Id, decimal? Cost, double? Count) : IRequest<DrugItem?>;