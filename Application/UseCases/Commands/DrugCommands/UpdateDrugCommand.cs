using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для обновления лекарства.
/// </summary>
public class UpdateDrugCommand : IRequest<Drug?>
{
    /// <summary>
    /// Уникальный идентификатор препарата.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название препарата.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Производитель препарата.
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string? CountryCodeId { get; set; }

    /// <summary>
    /// Связь с объектом Country.
    /// </summary>
    public Country? Country { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem>? DrugItems { get; set; }
}