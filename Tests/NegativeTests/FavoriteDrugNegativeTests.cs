using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности FavoriteDrug
/// </summary>
public class FavoriteDrugNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности FavoriteDrug
    /// </summary>
    public static IEnumerable<object[]> TestFavoriteDrugValidationExceptionData =
        NegativeTestsDataGenerator.GetFavoriteDrugValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра FavoriteDrug
    /// </summary>
    /// <param name="profileId"></param>
    /// <param name="profile"></param>
    /// <param name="drugId"></param>
    /// <param name="drug"></param>
    [Theory]
    [MemberData(nameof(TestFavoriteDrugValidationExceptionData))]
    public void Add_FavoriteDrugProperties_ThrowValidationException(
        Guid profileId,
        Profile profile,
        Guid drugId,
        Drug drug)
    {
        // Arrange
        var drugStore = DrugStoreGenerator.GenerateDrugStore();
        var drugStoreId = drugStore.Id;

        // Act
        var action = () => new FavoriteDrug(profileId, drugId, profile, drug, drugStoreId, drugStore);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}