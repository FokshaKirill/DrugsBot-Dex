using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

/// <summary>
/// Получение сущности FavoriteDrug по идентификатору запроса.
/// </summary>
/// <param name="Id"></param>
public record GetFavoriteDrugByIdQuery(Guid Id) : IRequest<FavoriteDrug?>;