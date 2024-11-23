using Application.Interfaces.Repositories.IFavoriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

/// <summary>
/// Хендлер для получения FavoriteDrug по идентификатору запроса.
/// </summary>
public class GetFavoriteDrugByIdQueryHandler : IRequestHandler<GetFavoriteDrugByIdQuery, FavoriteDrug?>
{
    /// <summary>
    /// Репозиторий чтения для сущности FavoriteDrug.
    /// </summary>
    private readonly IFavoriteDrugReadRepository _favoriteDrugReadRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="favoriteDrugReadRepository">Репозиторий чтения избранных препаратов.</param>
    public GetFavoriteDrugByIdQueryHandler(IFavoriteDrugReadRepository favoriteDrugReadRepository)
    {
        _favoriteDrugReadRepository = favoriteDrugReadRepository;
    }

    /// <summary>
    /// Метод обработки запроса на получение избранного лекарства по идентификатору.
    /// </summary>
    /// <param name="request">Запрос на получение сущности FavoriteDrug.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект сущности <see cref="FavoriteDrug"/> или null, если не найден.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<FavoriteDrug?> Handle(GetFavoriteDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _favoriteDrugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        return response;
    }
}