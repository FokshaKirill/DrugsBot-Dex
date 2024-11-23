using Domain.Entities;

namespace Application.Interfaces.Repositories.IProfileRepositories;

/// <summary>
/// Репозиторий чтения для сущности Profile
/// </summary>
public interface IProfileReadRepository : IReadRepository<Profile>
{
}