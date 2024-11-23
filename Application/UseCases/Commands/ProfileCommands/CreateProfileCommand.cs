using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Команда для создания профиля.
/// </summary>
public record CreateProfileCommand(string ExternalId, Email? Email) : IRequest<Guid>;