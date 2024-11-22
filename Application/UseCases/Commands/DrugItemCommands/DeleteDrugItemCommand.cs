using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Команда для удаления связи препарата и аптеки.
/// </summary>
public record DeleteDrugItemCommand(Guid Id) : IRequest<bool>;