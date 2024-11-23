using Application.Interfaces.Repositories.IProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

/// <summary>
/// Хендлер для получения Profile по идентификатору запроса.
/// </summary>
public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, Profile?>
{
    /// <summary>
    /// Репозиторий чтения для сущности Profile.
    /// </summary>
    private readonly IProfileReadRepository _profileReadRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="profileReadRepository"></param>
    public GetProfileByIdQueryHandler(IProfileReadRepository profileReadRepository)
    {
        _profileReadRepository = profileReadRepository;
    }

    /// <summary>
    /// Метод обработки запроса на получение профиля по идентификатору.
    /// </summary>
    /// <param name="request">Запрос на получение сущности Profile.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект сущности <see cref="Profile"/> или null, если не найден.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Profile?> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}