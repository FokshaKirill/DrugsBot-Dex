using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Хендлер для удаления связи препарата и аптеки.
/// </summary>
public class DeleteDrugItemCommandHandler : IRequestHandler<DeleteDrugItemCommand, bool>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteDrugItemCommandHandler"/>.
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий для записи и удаления данных о связях препаратов и аптек.</param>
    /// <param name="drugIteReadRepository">Репозиторий для чтения данных о связях препаратов и аптек.</param>
    public DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository,
        IDrugItemReadRepository drugIteReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugItemReadRepository = drugIteReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду удаления связи между препаратом и аптекой.
    /// </summary>
    /// <param name="request">Команда с идентификатором удаляемого объекта <see cref="DrugItem"/>.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если товар с указанным идентификатором не найден.</exception>
    public async Task<bool> Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drug == null)
        {
            throw new EntityNotFoundException(
                $"{request.GetType()} с данным Id {request.Id} не было найдено в системе.");
        }

        await _drugItemWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}