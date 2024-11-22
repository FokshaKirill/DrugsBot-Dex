using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Обработчик команды для обновления связи препарата и аптеки.
/// </summary>
public class UpdateDrugItemCommandHandler : IRequestHandler<UpdateDrugItemCommand, DrugItem?>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    public UpdateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugItemReadRepository = drugItemReadRepository;
    }

    public async Task<DrugItem?> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        // Получаем существующую сущность
        var drugItem = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drugItem == null)
        {
            throw new NotFoundException($"DrugItem with Id {request.Id} not found.");
        }

        // Обновляем необходимые свойства
        if (request.Cost.HasValue)
            drugItem.UpdateCost(request.Cost.Value);

        if (request.Count.HasValue)
            drugItem.UpdateCount(request.Count.Value);

        // Сохраняем изменения
        await _drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);

        return drugItem;
    }
}