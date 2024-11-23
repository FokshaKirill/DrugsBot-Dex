using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Хендлер для обновления связи препарата и аптеки.
/// </summary>
public class UpdateDrugItemCommandHandler : IRequestHandler<UpdateDrugItemCommand, DrugItem?>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="UpdateDrugItemCommandHandler"/>.
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий для записи данных о связях препаратов и аптек.</param>
    /// <param name="drugItemReadRepository">Репозиторий для чтения данных о связях препаратов и аптек.</param>
    public UpdateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugItemReadRepository = drugItemReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду обновления связи препарата и аптеки.
    /// </summary>
    /// <param name="request">Данные для обновления данных товара.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Обновленная сущность <see cref="DrugItem"/>, либо null, если обновление невозможно.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если товар с указанным идентификатором не найден.</exception>
    public async Task<DrugItem?> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drugItem == null)
        {
            throw new EntityNotFoundException(
                $"Товар с данным Id {request.Id} не был найден в системе.");
        }

        if (request.Cost.HasValue)
            drugItem.UpdateCost(request.Cost.Value);

        if (request.Count.HasValue)
            drugItem.UpdateCount(request.Count.Value);

        await _drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);

        return drugItem;
    }
}