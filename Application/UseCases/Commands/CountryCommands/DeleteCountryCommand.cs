using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Команда для удаления страны по её идентификатору.
/// </summary>
public class DeleteCountryCommand : IRequest<bool>
{
    /// <summary>
    /// Идентификатор страны.
    /// </summary>
    public Guid Id { get; set; }
}