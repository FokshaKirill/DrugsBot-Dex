using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для создания нового лекарства.
/// </summary>
public record CreateDrugCommand(
    Guid Id,
    string Name,
    string Manufacturer,
    string CountryCodeId,
    Country Country,
    ICollection<DrugItem> DrugItems) : IRequest<Drug?>;