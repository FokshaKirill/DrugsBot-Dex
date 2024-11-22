using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;

/// <summary>
/// Хендлер для получения запроса по идентификатору
/// </summary>
public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country?>
{
    /// <summary>
    /// Репозиторий чтения для сущности Country
    /// </summary>
    private readonly ICountryReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор хендлера
    /// </summary>
    /// <param name="drugItemReadRepository"></param>
    public GetCountryByIdQueryHandler(ICountryReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }

    /// <summary>
    /// Метод перехвата сущности Country
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}