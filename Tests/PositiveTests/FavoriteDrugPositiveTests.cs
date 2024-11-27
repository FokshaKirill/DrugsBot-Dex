using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Generators;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности FavoriteDrug
/// </summary>
public class FavoriteDrugPositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности FavoriteDrug
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра FavoriteDrug
    /// </summary>
    [Fact]
    public void Add_FavoriteDrug_ReturnNewFavoriteDrug()
    {
        // Arrange
        var profile = ProfileGenerator.GenerateProfile();
        var profileId = profile.Id;
        var drug = DrugGenerator.GenerateDrug();
        var drugId = drug.Id;
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        var drugStoreId = drugStore.Id;

        // Act
        var favouriteDrug = new FavoriteDrug(profileId, drugId, profile, drug, drugStoreId, drugStore);

        // Assert
        favouriteDrug.ProfileId.Should().Be(profileId);
        favouriteDrug.Profile.Should().Be(profile);
        favouriteDrug.DrugId.Should().Be(drugId);
        favouriteDrug.Drug.Should().Be(drug);
        favouriteDrug.DrugStoreId.Should().Be(drugStoreId);
        favouriteDrug.DrugStore.Should().Be(drugStore);
    }
}