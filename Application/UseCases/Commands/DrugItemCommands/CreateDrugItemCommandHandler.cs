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
    /// Обрабатывает команду создания связи между препаратом и аптеками.
    /// </summary>
    /// <param name="request">Команда с данными для создания связи.</param>
    /// <param name="cancellationToken">Токен отмены для управления задачей.</param>
    /// <returns>Созданная сущность <see cref="DrugItem"/>, либо null в случае ошибки.</returns>
    /// <exception cref="EntityAlreadyExistsException">Выбрасывается, если товар с таким названием уже существует.</exception>
    public async Task<DrugItem?> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);

        if (drug == null || drugStore == null)
        {
            throw new EntityAlreadyExistsException();
        }

        var drugItem = new DrugItem(request.DrugId, request.DrugStoreId, request.Cost, request.Count, drug, drugStore);

        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);

        return drugItem;
    }
}