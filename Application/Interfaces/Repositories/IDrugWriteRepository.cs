using Domain.Entities;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Репозиторий записи для сущности Drug
/// </summary>
public interface IDrugWriteRepository : IWriteRepository<Drug>
{
}