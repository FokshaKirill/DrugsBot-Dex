using Domain.Entities;

namespace Application.Interfaces.Repositories.IProfileRepositories;

/// <summary>
/// Репозиторий записи для сущности Profile
/// </summary>
public interface IProfileWriteRepository : IWriteRepository<Profile>
{
    new IReadOnlyList<Profile> ReadRepository { get; }
}