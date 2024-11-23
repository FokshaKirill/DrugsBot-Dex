using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

/// <summary>
/// Получение сущности DrugStore по идентификатору запроса.
/// </summary>
/// <param name="Id"></param>
public record GetDrugStoreByIdQuery(Guid Id) : IRequest<DrugStore?>;