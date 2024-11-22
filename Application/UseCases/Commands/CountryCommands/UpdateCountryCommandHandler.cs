using Application.Exceptions;
using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Хендлер для обновления информации о стране.
/// </summary>
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="countryWriteRepository"></param>
    /// <param name="countryReadRepository"></param>
    public UpdateCountryCommandHandler(ICountryWriteRepository countryWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработчик команды обновления страны.
    /// </summary>
    /// <param name="request">Данные для обновления страны.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная страна.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если страна с указанным идентификатором не найдена.</exception>
    public async Task<Country?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (country == null)
        {
            throw new EntityNotFoundException(
                $"{request.GetType()} с данным Id {request.Id} не было найдено в системе.");
        }

        if (!string.IsNullOrEmpty(request.Name))
            country.UpdateName(request.Name);

        if (!string.IsNullOrEmpty(request.Code))
            country.UpdateCode(request.Code);

        await _countryWriteRepository.UpdateAsync(country, cancellationToken);

        return country;
    }
}