using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands;

/// <summary>
/// Команда для удаления связи препарата и аптеки.
/// </summary>
public class DeleteDrugItemCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}