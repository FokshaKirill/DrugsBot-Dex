using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Хендлер для обновления данных аптеки.
/// </summary>
public class UpdateDrugStoreCommandHandler : IRequestHandler<UpdateDrugStoreCommand, DrugStore>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="UpdateDrugStoreCommandHandler"/>.
    /// </summary>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных аптеки.</param>
    /// <param name="drugStoreWriteRepository">Репозиторий для записи данных аптеки.</param>
    public UpdateDrugStoreCommandHandler(
        IDrugStoreReadRepository drugStoreReadRepository,
        IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }

    /// <summary>
    /// Обрабатывает команду обновления данных аптеки.
    /// </summary>
    /// <param name="request">Команда для обновления данных аптеки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленная сущность <see cref="DrugStore"/>, либо null, если обновление невозможно.</returns>
    /// <exception cref="EntityNotFoundException">Если аптека с указанным идентификатором не найдена.</exception>
    public async Task<DrugStore> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drugStore == null)
        {
            throw new EntityNotFoundException(
                $"Аптека с данным Id {request.Id} не была найдена в системе.");
        }

        if (!string.IsNullOrWhiteSpace(request.DrugNetwork))
        {
            drugStore.UpdateDrugNetwork(request.DrugNetwork);
        }

        if (request.Number.HasValue)
        {
            drugStore.UpdateNumber(request.Number.Value);
        }

        if (request.Address != null)
        {
            drugStore.UpdateAddress(request.Address);
        }

        await _drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);

        return drugStore;
    }
}