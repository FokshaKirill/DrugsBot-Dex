using Bogus;
using Domain.Entities;

namespace Tests.Generators;

public class CountryGenerator
{
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