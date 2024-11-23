using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;

/// <summary>
/// Получение сущности Country по идентификатору запроса.
/// </summary>
/// <param name="Id"></param>
public record GetCountryByIdQuery(Guid Id) : IRequest<Country?>;