using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Команда для обновления аптеки.
/// </summary>
public record UpdateDrugStoreCommand(Guid Id, string? DrugNetwork, int? Number, Address? Address) : IRequest<DrugStore>;