using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности DrugItem
/// </summary>
public class DrugItemNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности DrugItem
    /// </summary>
    public static IEnumerable<object[]> TestDrugItemValidationExceptionData =
        NegativeTestsDataGenerator.GetDrugItemValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра DrugItem
    /// </summary>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    /// <param name="cost"></param>
    /// <param name="count"></param>
    /// <param name="drug"></param>
    /// <param name="drugStore"></param>
    [Theory]
    [MemberData(nameof(TestDrugItemValidationExceptionData))]
    public void Add_DrugItemProperties_ThrowValidationException(Guid drugId, Drug drug, Guid drugStoreId,
        DrugStore drugStore, decimal cost, double count)
    {
        // Act
        var action = () => new DrugItem(drugId, drug, drugStoreId, drugStore, cost, count);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}