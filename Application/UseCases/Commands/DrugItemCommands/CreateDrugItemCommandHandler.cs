using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugItemRepositories;
using Application.Interfaces.Repositories.IDrugRepositories;
using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Хендлер для создания связи препарата и аптеки.
/// </summary>
public class CreateDrugItemCommandHandler : IRequestHandler<CreateDrugItemCommand, DrugItem?>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор хендлера для создания связи препарата и аптеки.
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий для записи связей препарата и аптеки.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о препаратах.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных об аптеках.</param>
    public CreateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IDrugReadRepository drugReadRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugReadRepository = drugReadRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду создания связи между препаратом и аптекой.
    /// </summary>
    /// <param name="request">Команда с данными для создания связи.</param>
    /// <param name="cancellationToken">Токен отмены для управления задачей.</param>
    /// <returns>Созданная сущность <see cref="DrugItem"/>, либо null в случае ошибки.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если препарат или аптека не найдены.</exception>
    public async Task<DrugItem?> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        // Проверяем существование препарата
        var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        if (drug == null)
        {
            throw new EntityNotFoundException($"Препарат с Id {request.DrugId} не найден.");
        }

        // Проверяем существование аптеки
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);
        if (drugStore == null)
        {
            throw new EntityNotFoundException($"Аптека с Id {request.DrugStoreId} не найдена.");
        }

        // Создаем новый объект DrugItem
        var drugItem = new DrugItem(request.DrugId, request.DrugStoreId, request.Cost, request.Count, drug, drugStore);

        // Сохраняем объект в базе данных
        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);

        return drugItem;
    }
}