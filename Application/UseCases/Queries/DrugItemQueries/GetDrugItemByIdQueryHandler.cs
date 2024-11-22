using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;

/// <summary>
/// Хендлер для получения запроса по идентификатору
/// </summary>
public class GetDrugItemByIdQueryHandler : IRequestHandler<GetDrugItemByIdQuery, DrugItem?>
{
    /// <summary>
    /// Репозиторий чтения для сущности DrugItem
    /// </summary>
    private readonly IDrugItemReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор хендлера
    /// </summary>
    /// <param name="drugItemReadRepository"></param>
    public GetDrugItemByIdQueryHandler(IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }

    /// <summary>
    /// Метод перехвата сущности DrugItem
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<DrugItem?> Handle(GetDrugItemByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}