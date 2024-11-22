using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Команда для создания новой страны.
/// </summary>
public class CreateCountryCommand : IRequest<Country?>
{
    /// <summary>
    /// Название страны.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название страны.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Код страны (например, ISO-код).
    /// </summary>
    public string Code { get; set; }
}