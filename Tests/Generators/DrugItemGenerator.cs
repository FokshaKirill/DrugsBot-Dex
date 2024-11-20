using Bogus;
using Domain.Entities;

namespace Tests.Generators;

public class DrugItemGenerator
{
    private static readonly Faker<DrugItem> Faker = new Faker<DrugItem>()
        .CustomInstantiator(f =>
        {
            var drugStore = DrugStoreGenerator.GenerateDrugStore();
            var drug = DrugGenerator.GenerateDrug();
            
            return new DrugItem(
                drug.Id,
                drugStore.Id,
                f.Random.Decimal(1, 1000),
                f.Random.Int(1, 1000),
                drug,
                drugStore
            );
        });
    
    /// <summary>
    /// Генерация лекарства
    /// </summary>
    /// <returns>Лекарство.</returns>
    public static DrugItem GenerateDrugItem()
    {
        return Faker.Generate();
    }
}