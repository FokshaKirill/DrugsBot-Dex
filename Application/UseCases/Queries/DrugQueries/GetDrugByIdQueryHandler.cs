using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

/// <summary>
/// Хендлер для получения Drug по идентификатору запроса.
/// </summary>
public class GetDrugByIdQueryHandler : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    /// <summary>
    /// Репозиторий чтения для сущности Drug.
    /// </summary>
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="drugReadRepository"></param>
    public GetDrugByIdQueryHandler(IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Метод обработки запроса на получение лекарства по идентификатору.
    /// </summary>
    /// <param name="request">Запрос на получение сущности Drug.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект сущности <see cref="Drug"/> или null, если не найден.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}