using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

/// <summary>
/// Хендлер для получения запроса по идентификатору
/// </summary>
public class GetByIdQueryHandler : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    /// <summary>
    /// Репозиторий чтения для сущности Drug
    /// </summary>
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Конструктор хендлера
    /// </summary>
    /// <param name="drugReadRepository"></param>
    public GetByIdQueryHandler(IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Метод перехвата сущности Drug
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}