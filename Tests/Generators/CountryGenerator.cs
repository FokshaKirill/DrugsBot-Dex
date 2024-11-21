using Bogus;
using Domain.Entities;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности DrugStore
/// </summary>
public class CountryGenerator
{
    /// <summary>
    /// Генератор фальшивых данных для сущности Country
    /// </summary>
    private static readonly Faker<Country> Faker = new Faker<Country>()
        .CustomInstantiator(f => new Country(
            f.Random.String2(10),
            f.PickRandom(Country.ValidCountryCodes.ToList())
        ));

    /// <summary>
    /// Генерация страны
    /// </summary>
    /// <returns>Страна.</returns>
    public static Country GenerateCountry()
    {
        return Faker.Generate();
    }
}