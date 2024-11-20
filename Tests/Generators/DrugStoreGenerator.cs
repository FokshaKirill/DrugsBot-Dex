using Bogus;
using Domain.Entities;

namespace Tests.Generators;

public class DrugStoreGenerator
{
    private static readonly Faker<DrugStore> Faker = new Faker<DrugStore>()
        .CustomInstantiator(f =>
        {
            var address = AddressGenerator.GenerateAddress();
            
            return new DrugStore(
                f.Random.String2(10),
                f.Random.Int(1, 1000),
                address
            );
        });
    
    /// <summary>
    /// Генерация магазина
    /// </summary>
    /// <returns>Магазин.</returns>
    public static DrugStore GenerateDrugStore()
    {
        return Faker.Generate();
    }
}