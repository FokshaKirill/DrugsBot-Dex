using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;

/// <summary>
/// Хендлер для получения DrugItem по идентификатору запроса.
/// </summary>
public class GetDrugItemByIdQueryHandler : IRequestHandler<GetDrugItemByIdQuery, DrugItem?>
{
    /// <summary>
    /// Репозиторий чтения для сущности DrugItem.
    /// </summary>
    private readonly IDrugItemReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="drugItemReadRepository"></param>
    public GetDrugItemByIdQueryHandler(IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }

    /// <summary>
    /// Метод обработки запроса на получение товара по идентификатору.
    /// </summary>
    /// <param name="request">Запрос на получение сущности DrugItem.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект сущности <see cref="DrugItem"/> или null, если не найден.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<DrugItem?> Handle(GetDrugItemByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}