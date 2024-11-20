using Bogus;
using Domain.ValueObjects;

namespace Tests.Generators;

public class AddressGenerator
{
    private static readonly Faker<Address> Faker = new Faker<Address>()
        .CustomInstantiator(f => new Address(
                f.Random.String2(10), 
                f.Random.String2(10),
                f.Random.Int(1, 1000),
                f.Random.Int(1, 1000)
            )
        );
    
    /// <summary>
    /// Генерация адреса
    /// </summary>
    /// <returns>Адрес.</returns>
    public static Address GenerateAddress()
    {
        return Faker.Generate();
    }
}