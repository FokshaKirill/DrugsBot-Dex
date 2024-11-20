using Bogus;
using Domain.Entities;
using Domain.ValueObjects;

namespace Tests.Generators;

public class ProfileGenerator
{
    private static readonly Faker<Profile> Faker = new Faker<Profile>()
        .CustomInstantiator(f =>
        {
            var email = new Email(f.Internet.Email());
            
            return new Profile(
                f.Random.String(1000000, 9999999),
                email
            );
        });
    
    /// <summary>
    /// Генерация профиля
    /// </summary>
    /// <returns>Профиль.</returns>
    public static Profile GenerateProfile()
    {
        return Faker.Generate();
    }
}