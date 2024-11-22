﻿using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugRepositories;

/// <summary>
/// Репозиторий записи для сущности Drug
/// </summary>
public interface IDrugWriteRepository : IWriteRepository<Drug>
{
    IReadOnlyList<Drug> ReadRepository { get; }
}