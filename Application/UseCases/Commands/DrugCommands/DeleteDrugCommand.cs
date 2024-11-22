using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для удаления лекарства.
/// </summary>
public record DeleteDrugCommand(Guid Id) : IRequest<bool>;