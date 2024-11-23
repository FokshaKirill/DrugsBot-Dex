using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

/// <summary>
/// Хендлер для получения DrugStore по идентификатору запроса.
/// </summary>
public class GetDrugStoreByIdQueryHandler : IRequestHandler<GetDrugStoreByIdQuery, DrugStore?>
{
    /// <summary>
    /// Репозиторий чтения для сущности DrugStore.
    /// </summary>
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="drugStoreReadRepository"></param>
    public GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Метод обработки запроса на получение аптеки по идентификатору.
    /// </summary>
    /// <param name="request">Запрос на получение сущности DrugStore.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект сущности <see cref="DrugStore"/> или null, если не найден.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<DrugStore?> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}