using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Хендлер для команды удаления лекарства.
/// </summary>
public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, bool>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteDrugCommandHandler"/>.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи.</param>
    /// <param name="drugReadRepository">Репозиторий чтения.</param>
    public DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository, IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Обработка команды удаления лекарства.
    /// </summary>
    /// <param name="request">Команда для удаления Drug.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если лекарство с указанным идентификатором не найдено.</exception>
    public async Task<bool> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drug == null)
        {
            throw new EntityNotFoundException(
                $"Лекарство с данным Id {request.Id} не было найдено в системе.");
        }

        await _drugWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}