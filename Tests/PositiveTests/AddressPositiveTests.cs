using Bogus;
using Domain.ValueObjects;
using FluentAssertions;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности Address
/// </summary>
public class AddressPositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности Address
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра Address
    /// </summary>
    [Fact]
    public void Add_Address_ReturnNewAddress()
    {
        // Arrange
        var city = _faker.Random.String2(10);
        var street = _faker.Random.String2(10);
        var house = _faker.Random.Int(1, 100);
        var postalCode = _faker.Random.Int(10000, 999999);

        // Act
        var address = new Address(city, street, house, postalCode);

        // Assert
        address.City.Should().Be(city);
        address.Street.Should().Be(street);
        address.House.Should().Be(house);
        address.PostalCode.Should().Be(postalCode);
    }
}