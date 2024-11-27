using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Generators;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности DrugStore
/// </summary>
public class DrugStorePositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности DrugStore
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра DrugStore
    /// </summary>
    [Fact]
    public void Add_DrugStore_ReturnNewDrugStore()
    {
        // Arrange
        var drugNetwork = _faker.Random.String2(10);
        var number = _faker.Random.Int(1, 100);
        var address = AddressGenerator.GenerateAddress();

        // Act
        var drugStore = new DrugStore(drugNetwork, number, address);

        // Assert
        drugStore.DrugNetwork.Should().Be(drugNetwork);
        drugStore.Number.Should().Be(number);
        drugStore.Address.Should().Be(address);
    }
}