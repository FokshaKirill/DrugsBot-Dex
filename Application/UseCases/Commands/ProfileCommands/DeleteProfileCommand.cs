using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Команда для удаления профиля.
/// </summary>
public record DeleteProfileCommand(Guid Id) : IRequest<bool>;