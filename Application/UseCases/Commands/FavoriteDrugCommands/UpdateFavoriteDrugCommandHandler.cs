using Application.Exceptions;
using Application.Interfaces.Repositories.IFavoriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands;

/// <summary>
/// Хендлер для обновления информации об избранном лекарстве.
/// </summary>
public class UpdateFavoriteDrugCommandHandler : IRequestHandler<UpdateFavoriteDrugCommand, bool>
{
    private readonly IFavoriteDrugReadRepository _favoriteDrugReadRepository;
    private readonly IFavoriteDrugWriteRepository _favoriteDrugWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="UpdateFavoriteDrugCommandHandler"/>.
    /// </summary>
    /// <param name="favoriteDrugReadRepository"></param>
    /// <param name="favoriteDrugWriteRepository"></param>
    public UpdateFavoriteDrugCommandHandler(
        IFavoriteDrugReadRepository favoriteDrugReadRepository,
        IFavoriteDrugWriteRepository favoriteDrugWriteRepository)
    {
        _favoriteDrugReadRepository = favoriteDrugReadRepository;
        _favoriteDrugWriteRepository = favoriteDrugWriteRepository;
    }

    /// <summary>
    /// Обрабатывает команду обновления данных избранного лекарства.
    /// </summary>
    /// <param name="request">Команда для обновления данных избранного лекарства.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленная сущность <see cref="FavoriteDrug"/>, либо null, если обновление невозможно.</returns>
    /// <exception cref="EntityNotFoundException">Если избранное лекарство с указанным идентификатором не найдено.</exception>
    public async Task<bool> Handle(UpdateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favoriteDrug = await _favoriteDrugReadRepository.GetByIdAsync(request.Id, cancellationToken)
                           ?? throw new EntityNotFoundException($"Избранное лекарство с Id {request.Id} не найдено.");

        favoriteDrug.UpdateDrugStore(request.DrugStoreId, null);

        await _favoriteDrugWriteRepository.UpdateAsync(favoriteDrug, cancellationToken);

        return true;
    }
}