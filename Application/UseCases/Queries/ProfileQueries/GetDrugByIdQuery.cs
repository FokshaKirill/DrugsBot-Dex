using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

/// <summary>
/// Получение сущности Profile по идентификатору запроса.
/// </summary>
/// <param name="Id"></param>
public record GetProfileByIdQuery(Guid Id) : IRequest<Profile?>;