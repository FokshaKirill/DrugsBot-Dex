using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugStoreRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Хендлер для удаления аптеки.
/// </summary>
public class DeleteDrugStoreCommandHandler : IRequestHandler<DeleteDrugStoreCommand, bool>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteDrugStoreCommandHandler"/>.
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий для записи данных аптек.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных аптек.</param>
    public DeleteDrugStoreCommandHandler(
        IDrugStoreWriteRepository drugStoreWriteRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду удаления аптеки.
    /// </summary>
    /// <param name="request">Команда для удаления DrugStore.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если аптека с указанным идентификатором не найдена.</exception>
    public async Task<bool> Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drugStore == null)
        {
            throw new EntityNotFoundException(
                $"Аптека с данным Id {request.Id} не была найдена в системе.");
        }

        await _drugStoreWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}