using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugRepositories;
using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Application.Interfaces.Repositories.IFavoriteDrugRepositories;
using Application.Interfaces.Repositories.IProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands;

/// <summary>
/// Хендлер для создания избранного лекарства.
/// </summary>
public class CreateFavoriteDrugCommandHandler : IRequestHandler<CreateFavoriteDrugCommand, Guid>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IFavoriteDrugWriteRepository _favoriteDrugWriteRepository;
    private readonly IProfileReadRepository _profileReadRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CreateFavoriteDrugCommandHandler"/>.
    /// </summary>
    /// <param name="favoriteDrugWriteRepository">Репозиторий для записи избранного лекарства.</param>
    /// <param name="profileReadRepository">Репозиторий для чтения данных о профилях.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о лекарствах.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных об аптеках.</param>
    public CreateFavoriteDrugCommandHandler(
        IFavoriteDrugWriteRepository favoriteDrugWriteRepository,
        IProfileReadRepository profileReadRepository,
        IDrugReadRepository drugReadRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _favoriteDrugWriteRepository = favoriteDrugWriteRepository;
        _profileReadRepository = profileReadRepository;
        _drugReadRepository = drugReadRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду для создания избранного лекарства.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task<Guid> Handle(CreateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileReadRepository.GetByIdAsync(request.ProfileId, cancellationToken)
                      ?? throw new EntityNotFoundException($"Профиль с Id {request.ProfileId} не найден.");

        var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken)
                   ?? throw new EntityNotFoundException($"Препарат с Id {request.DrugId} не найден.");

        DrugStore? drugStore = null;
        if (request.DrugStoreId.HasValue)
        {
            drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId.Value, cancellationToken);
        }

        var favoriteDrug = new FavoriteDrug(request.ProfileId, request.DrugId, profile, drug, request.DrugStoreId,
            drugStore);

        await _favoriteDrugWriteRepository.AddAsync(favoriteDrug, cancellationToken);

        return favoriteDrug.Id;
    }
}