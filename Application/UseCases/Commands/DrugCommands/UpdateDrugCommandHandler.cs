using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Хендлер для обновления сущности лекарства.
/// </summary>
public class UpdateDrugCommandHandler : IRequestHandler<UpdateDrugCommand, Drug?>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="UpdateDrugCommandHandler"/>.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий для записи данных о лекарствах.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о лекарствах.</param>
    public UpdateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,
        IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду для обновления данных о лекарстве.
    /// </summary>
    /// <param name="request">Объект команды с данными для обновления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленная сущность <see cref="Drug"/>, либо null, если обновление невозможно.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если лекарство с указанным идентификатором не найдено.</exception>
    public async Task<Drug?> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drug == null)
        {
            throw new EntityNotFoundException(
                $"Лекарство с данным Id {request.Id} не было найдено в системе.");
        }

        if (!string.IsNullOrEmpty(request.Name))
            drug.UpdateName(request.Name);

        if (!string.IsNullOrEmpty(request.Manufacturer))
            drug.UpdateManufacturer(request.Manufacturer);

        if (!string.IsNullOrEmpty(request.CountryCodeId))
            drug.UpdateCountryCode(request.CountryCodeId);

        if (request.Country != null)
            drug.UpdateCountry(request.Country);

        if (request.DrugItems != null && request.DrugItems.Any())
            drug.UpdateDrugItems(request.DrugItems);

        await _drugWriteRepository.UpdateAsync(drug, cancellationToken);

        return drug;
    }
}