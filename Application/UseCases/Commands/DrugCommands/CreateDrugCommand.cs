using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// 
/// </summary>
public class CreateDrugCommand : IRequest<Drug?>
{
    /// <summary>
    /// Название препарата.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Производитель препарата.
    /// </summary>
    public string Manufacturer { get; set; }

    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string CountryCodeId { get; set; }

    /// <summary>
    /// Связь с объектом Country.
    /// </summary>
    public Country Country { get; set; }
}