using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Базовый репозиторий чтения
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Получение сущности по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение запросов с помощью OData
    /// </summary>
    /// <param name="queryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IQueryable<T>> GetQueryableAsync(ODataQueryOptions queryOptions,
        CancellationToken cancellationToken = default);
}