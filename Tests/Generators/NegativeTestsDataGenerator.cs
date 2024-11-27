using Bogus;
using Domain.ValueObjects;

namespace Tests.Generators;

/// <summary>
/// Генерация данных для негативных тестов
/// </summary>
public class NegativeTestsDataGenerator
{
    private static readonly Faker Faker = new();

    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности Drug
    /// </summary>
    public static IEnumerable<object[]> GetDrugValidationExceptionProperties()
    {
        var country = CountryGenerator.GenerateCountry();

        return new List<object[]>
        {
            new object[] { null, Faker.Random.String2(10), country.Code, country },
            new object[] { Faker.Random.String2(10), null, country.Code, country },
            new object[] { Faker.Random.String2(10), Faker.Random.String2(10), null, country },
            new object[] { Faker.Random.String2(10), Faker.Random.String2(10), country.Code, null }
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности Country
    /// </summary>
    public static IEnumerable<object[]> GetCountryValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] { null, Faker.Random.Int(1, 1000).ToString() },
            new object[] { Faker.Random.String2(10), null }
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности DrugStore
    /// </summary>
    public static IEnumerable<object[]> GetDrugStoreValidationExceptionProperties()
    {
        var address = AddressGenerator.GenerateAddress();

        return new List<object[]>
        {
            new object[] { null, Faker.Random.Int(1, 1000), address },
            new object[] { Faker.Random.String2(10), -1, address },
            new object[] { Faker.Random.String2(10), Faker.Random.Int(1, 1000), null },
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности DrugItem
    /// </summary>
    public static IEnumerable<object[]> GetDrugItemValidationExceptionProperties()
    {
        var drug = DrugGenerator.GenerateDrug();
        var drugStore = DrugStoreGenerator.GenerateDrugStore();

        return new List<object[]>
        {
            new object[] { null, drug, drugStore.Id, drugStore, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] { drug.Id, null, drugStore.Id, drugStore, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] { drug.Id, drug, null, drugStore, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] { drug.Id, drug, drugStore.Id, null, Faker.Random.Decimal(1), Faker.Random.Int(1, 1000) },
            new object[] { drug.Id, drug, drugStore.Id, drugStore, -1, Faker.Random.Int(1, 1000) },
            new object[] { drug.Id, drug, drugStore.Id, drugStore, Faker.Random.Decimal(1), -1 }
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у сущности FavouriteDrug
    /// </summary>
    public static IEnumerable<object[]> GetFavoriteDrugValidationExceptionProperties()
    {
        var profile = ProfileGenerator.GenerateProfile();
        var drug = DrugGenerator.GenerateDrug();

        return new List<object[]>
        {
            new object[] { null, profile, drug.Id, drug },
            new object[] { profile.Id, null, drug.Id, drug },
            new object[] { profile.Id, profile, null, drug },
            new object[] { profile.Id, profile, drug.Id, null }
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у ProfileGenerator
    /// </summary>
    public static IEnumerable<object[]> GetProfileValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] { null, new Email(Faker.Internet.Email()) },
            new object[] { Faker.Random.Int(100000, 9999999), null }
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у значимого объекта Address
    /// </summary>
    public static IEnumerable<object[]> GetAddressValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[]
                { null, Faker.Address.StreetName(), Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999) },
            new object[] { Faker.Address.City(), null, Faker.Random.Int(1, 100), Faker.Random.Int(10000, 999999) },
            new object[] { Faker.Address.City(), Faker.Address.StreetName(), null, Faker.Random.Int(10000, 999999) },
            new object[] { Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 100), null }
        };
    }

    /// <summary>
    /// Генерация данных для исключения ValidationException у значимого объекта Email
    /// </summary>
    public static IEnumerable<object[]> GetEmailValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] { Faker.Random.String2(10) }
        };
    }
}