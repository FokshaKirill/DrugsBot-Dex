using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Хендлер для команды удаления лекарства.
/// </summary>
public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, bool>
{
    /// <summary>
    /// Репозиторий чтения для проверки существования лекарства.
    /// </summary>
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Репозиторий записи для работы с сущностью Drug.
    /// </summary>
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Конструктор хендлера удаления лекарства.
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
    /// <param name="request">Команда удаления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    public async Task<bool> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        // Проверяем, существует ли лекарство с указанным Id
        var drug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drug == null)
        {
            throw new NotFoundException($"{request.GetType()} с данным Id {request.Id} не было найдено в системе.");
        }

        // Удаляем лекарство
        await _drugWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}