using Bogus;
using Domain.Entities;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности DrugStore
/// </summary>
public class DrugGenerator
{
    /// <summary>
    /// Генератор фальшивых данных для сущности DrugStore
    /// </summary>
    private static readonly Faker<Drug> Faker = new Faker<Drug>()
        .CustomInstantiator(f =>
        {
            var country = CountryGenerator.GenerateCountry();

            return new Drug(
                f.Random.String2(10),
                f.Random.String2(10),
                country.Code,
                country
            );
        });

    /// <summary>
    /// Генерация лекарства
    /// </summary>
    /// <returns>Лекарство.</returns>
    public static Drug GenerateDrug()
    {
        return Faker.Generate();
    }
}