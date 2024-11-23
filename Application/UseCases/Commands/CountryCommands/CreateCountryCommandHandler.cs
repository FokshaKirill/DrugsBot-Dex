using Application.Exceptions;
using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Хендлер для создания новой страны.
/// </summary>
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="countryWriteRepository"></param>
    /// <param name="countryReadRepository"></param>
    public CreateCountryCommandHandler(ICountryWriteRepository countryWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработчик команды создания новой страны.
    /// </summary>
    /// <param name="request">Данные для создания страны.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданная страна.</returns>
    /// <exception cref="EntityAlreadyExistsException">Если страна с таким кодом или названием уже существует.</exception>
    public async Task<Country?> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var existingCountry = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingCountry != null)
        {
            throw new EntityAlreadyExistsException();
        }

        var country = new Country(
            request.Name,
            request.Code
        );

        await _countryWriteRepository.AddAsync(country, cancellationToken);

        return country;
    }
}