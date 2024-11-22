using Application.Exceptions;
using Application.Interfaces.Repositories.ICountryRepositories;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Хендлер для удаления страны.
/// </summary>
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="countryWriteRepository"></param>
    /// <param name="countryReadRepository"></param>
    public DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработчик команды удаления страны.
    /// </summary>
    /// <param name="request">Данные для удаления страны.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус успешного удаления.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если страна с указанным идентификатором не найдена.</exception>
    public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (country == null)
        {
            throw new EntityNotFoundException(
                $"{request.GetType()} с данным Id {request.Id} не было найдено в системе.");
        }

        await _countryWriteRepository.DeleteAsync(request.Id, cancellationToken);
        return true;
    }
}