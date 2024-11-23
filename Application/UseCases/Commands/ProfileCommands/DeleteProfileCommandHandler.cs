using Application.Exceptions;
using Application.Interfaces.Repositories.IProfileRepositories;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Хендлер для удаления профиля.
/// </summary>
public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, bool>
{
    private readonly IProfileReadRepository _profileReadRepository;
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="DeleteProfileCommandHandler"/>.
    /// </summary>
    /// <param name="profileWriteRepository"></param>
    /// <param name="profileReadRepository"></param>
    public DeleteProfileCommandHandler(
        IProfileWriteRepository profileWriteRepository,
        IProfileReadRepository profileReadRepository)
    {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
    }

    /// <summary>
    /// Обработка команды удаления профиля.
    /// </summary>
    /// <param name="request">Команда для удаления Profile.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если профиль с указанным идентификатором не найден.</exception>
    public async Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (profile == null)
        {
            throw new EntityNotFoundException($"Профиль с Id {request.Id} не найден.");
        }

        await _profileWriteRepository.DeleteAsync(request.Id, cancellationToken);
        return true;
    }
}