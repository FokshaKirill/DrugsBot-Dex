using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Обработчик команды для создания нового лекарства.
/// </summary>
public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Drug?>
{
    /// <summary>
    /// Репозиторий для чтения данных о лекарствах.
    /// </summary>
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Репозиторий для записи данных о лекарствах.
    /// </summary>
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CreateDrugCommandHandler"/>.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий для записи данных о лекарствах.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о лекарствах.</param>
    public CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,
        IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду создания нового лекарства.
    /// </summary>
    /// <param name="request">Данные для создания лекарства.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Созданное лекарство или <c>null</c>, если операция не выполнена.</returns>
    /// <exception cref="DrugAlreadyExistsException">Выбрасывается, если лекарство с таким названием уже существует.</exception>
    public async Task<Drug?> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        // Проверяем, существует ли уже лекарство с таким именем
        var existingDrug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingDrug != null)
        {
            throw new DrugAlreadyExistsException();
        }

        // Создаем новый объект лекарства
        var drug = new Drug(
            request.Name,
            request.Manufacturer,
            request.CountryCodeId,
            request.Country,
            new List<DrugItem>()
        );

        // Добавляем его в базу данных
        await _drugWriteRepository.AddAsync(drug, cancellationToken);

        // Возвращаем созданный объект
        return drug;
    }
}