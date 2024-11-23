using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries;

/// <summary>
/// Получение сущности DrugItem по идентификатору запроса.
/// </summary>
/// <param name="Id"></param>
public record GetDrugItemByIdQuery(Guid Id) : IRequest<DrugItem?>;