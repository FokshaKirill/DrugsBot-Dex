using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для обновления лекарства.
/// </summary>
public record UpdateDrugCommand(
    Guid Id,
    string? Name,
    string? Manufacturer,
    string? CountryCodeId,
    Country? Country,
    ICollection<DrugItem>? DrugItems) : IRequest<Drug?>;