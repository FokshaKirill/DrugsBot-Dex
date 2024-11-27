using Bogus;
using Domain.Entities;

namespace Tests.Generators;

/// <summary>
/// Генератор сущности DrugStore
/// </summary>
public class DrugItemGenerator
{
    /// <summary>
    /// Генератор фальшивых данных для сущности DrugItem
    /// </summary>
    private static readonly Faker<DrugItem> Faker = new Faker<DrugItem>()
        .CustomInstantiator(f =>
        {
            var drugStore = DrugStoreGenerator.GenerateDrugStore();
            var drug = DrugGenerator.GenerateDrug();

            return new DrugItem(
                drug.Id,
                drug,
                drugStore.Id,
                drugStore,
                Math.Round(f.Random.Decimal(), 2),
                f.Random.Int(1, 1000)
            );
        });

    /// <summary>
    /// Генерация товара
    /// </summary>
    /// <returns>Товар.</returns>
    public static DrugItem GenerateDrugItem()
    {
        return Faker.Generate();
    }
}