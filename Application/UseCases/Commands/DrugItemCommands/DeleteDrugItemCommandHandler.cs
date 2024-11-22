using Application.Interfaces.Repositories.IDrugItemRepositories;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Обработчик команды для удаления связи препарата и аптеки.
/// </summary>
public class DeleteDrugItemCommandHandler : IRequestHandler<DeleteDrugItemCommand, bool>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    public DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
    }

    public async Task<bool> Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        await _drugItemWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}