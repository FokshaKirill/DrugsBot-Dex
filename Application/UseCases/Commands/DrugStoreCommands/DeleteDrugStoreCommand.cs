using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Команда для удаления аптеки.
/// </summary>
public record DeleteDrugStoreCommand(Guid Id) : IRequest<bool>;