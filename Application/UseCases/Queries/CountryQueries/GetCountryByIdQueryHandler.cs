using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;

/// <summary>
/// Хендлер для получения Country по идентификатору запроса.
/// </summary>
public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country?>
{
    /// <summary>
    /// Репозиторий чтения для сущности Country.
    /// </summary>
    private readonly ICountryReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="drugItemReadRepository"></param>
    public GetCountryByIdQueryHandler(ICountryReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }

    /// <summary>
    /// Метод обработки запроса на получение страны по идентификатору.
    /// </summary>
    /// <param name="request">Запрос на получение сущности Country.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект сущности <see cref="Country"/> или null, если не найден.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}