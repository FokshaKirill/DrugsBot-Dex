namespace Application.Interfaces.Repositories;

/// <summary>
/// Базовый репозиторий записи
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IWriteRepository<T> where T : class
{
    /// <summary>
    /// Репозиторий для операций чтения базы данных
    /// </summary>
    IReadRepository<T> ReadRepository { get; }

    /// <summary>
    /// Метод для добавления сущности
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Метод для редактирования сущности
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Метод для удаления сущности
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}