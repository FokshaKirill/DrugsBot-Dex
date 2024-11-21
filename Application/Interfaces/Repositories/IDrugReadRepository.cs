using Domain.Entities;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Репозиторий чтения для сущности Drug
/// </summary>
public interface IDrugReadRepository : IReadRepository<Drug>
{
}