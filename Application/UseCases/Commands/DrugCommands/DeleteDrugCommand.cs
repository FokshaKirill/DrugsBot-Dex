using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для удаления лекарства.
/// </summary>
public class DeleteDrugCommand : IRequest<bool>
{
    /// <summary>
    /// Конструктор команды удаления лекарства.
    /// </summary>
    /// <param name="id">Уникальный идентификатор лекарства.</param>
    public DeleteDrugCommand(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Уникальный идентификатор лекарства.
    /// </summary>
    public Guid Id { get; set; }
}