using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Generators;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности DrugItem
/// </summary>
public class DrugItemPositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности DrugItem
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра DrugItem
    /// </summary>
    [Fact]
    public void Add_DrugItem_ReturnNewDrugItem()
    {
        // Arrange
        var drug = DrugGenerator.GenerateDrug();
        var drugId = drug.Id;
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        var drugStoreId = drugStore.Id;
        var cost = Math.Round(_faker.Random.Decimal(), 2);
        var count = _faker.Random.Double(0, 10000);

        // Act
        var drugItem = new DrugItem(drugId, drug, drugStoreId, drugStore, cost, count);

        // Assert
        drugItem.DrugId.Should().Be(drugId);
        drugItem.DrugStoreId.Should().Be(drugStoreId);
        drugItem.Cost.Should().Be(cost);
        drugItem.Count.Should().Be(count);
        drugItem.Drug.Should().Be(drug);
        drugItem.DrugStore.Should().Be(drugStore);
    }
}