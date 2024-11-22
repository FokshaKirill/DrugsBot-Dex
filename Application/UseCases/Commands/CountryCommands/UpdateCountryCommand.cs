using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Команда для обновления информации о стране.
/// </summary>
public class UpdateCountryCommand : IRequest<Country?>
{
    /// <summary>
    /// Идентификатор страны.
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