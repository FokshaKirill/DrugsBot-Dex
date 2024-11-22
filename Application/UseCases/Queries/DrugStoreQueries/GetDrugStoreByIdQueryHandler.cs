﻿using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

/// <summary>
/// Хендлер для получения запроса по идентификатору
/// </summary>
public class GetDrugStoreByIdQueryHandler : IRequestHandler<GetDrugStoreByIdQuery, DrugStore?>
{
    /// <summary>
    /// Репозиторий чтения для сущности DrugStore
    /// </summary>
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор хендлера
    /// </summary>
    /// <param name="drugStoreReadRepository"></param>
    public GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Метод перехвата сущности DrugStore
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<DrugStore?> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}