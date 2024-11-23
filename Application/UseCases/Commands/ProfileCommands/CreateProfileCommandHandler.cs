using Application.Interfaces.Repositories.IProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Хендлер для создания профиля.
/// </summary>
public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CreateProfileCommandHandler"/>.
    /// </summary>
    /// <param name="profileWriteRepository"></param>
    public CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }

    /// <summary>
    /// Обработка команды для создания профиля.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = new Profile(request.ExternalId, request.Email);
        await _profileWriteRepository.AddAsync(profile, cancellationToken);
        return profile.Id;
    }
}