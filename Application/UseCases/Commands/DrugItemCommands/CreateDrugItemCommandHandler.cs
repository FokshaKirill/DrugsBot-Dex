using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugItemRepositories;
using Application.Interfaces.Repositories.IDrugRepositories;
using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Обработчик команды для создания связи препарата и аптеки.
/// </summary>
public class CreateDrugItemCommandHandler : IRequestHandler<CreateDrugItemCommand, DrugItem?>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    public CreateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IDrugReadRepository drugReadRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugReadRepository = drugReadRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    public async Task<DrugItem?> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        // Проверяем существование препарата и аптеки
        var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);

        if (drug == null || drugStore == null)
        {
            throw new NotFoundException("Drug or DrugStore not found.");
        }

        // Создаем новую сущность DrugItem
        var drugItem = new DrugItem(request.DrugId, request.DrugStoreId, request.Cost, request.Count, drug, drugStore);

        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);

        return drugItem;
    }
}