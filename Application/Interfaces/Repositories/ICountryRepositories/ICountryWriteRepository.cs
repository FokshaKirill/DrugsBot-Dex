using Domain.Entities;

namespace Application.Interfaces.Repositories.ICountryRepositories;

/// <summary>
/// Репозиторий записи для сущности Country
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>
{
    IReadOnlyList<Country> ReadRepository { get; }
}