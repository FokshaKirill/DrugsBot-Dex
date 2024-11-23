using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands;

/// <summary>
/// Команда для обновления информации об избранном лекарстве.
/// </summary>
public record UpdateFavoriteDrugCommand(Guid Id, Guid? DrugStoreId) : IRequest<bool>;