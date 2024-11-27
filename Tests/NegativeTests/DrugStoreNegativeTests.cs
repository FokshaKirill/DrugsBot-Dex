using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности DrugStore
/// </summary>
public class DrugStoreNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности DrugStore
    /// </summary>
    public static IEnumerable<object[]> TestDrugStoreValidationExceptionData =
        NegativeTestsDataGenerator.GetDrugStoreValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра DrugStore
    /// </summary>
    /// <param name="drugNetwork">Аптечная сеть.</param>
    /// <param name="number">Номер.</param>
    /// <param name="address">Адрес.</param>
    [Theory]
    [MemberData(nameof(TestDrugStoreValidationExceptionData))]
    public void Add_DrugStoreProperties_ThrowValidationException(
        string drugNetwork,
        int number,
        Address address)
    {
        // Act
        var action = () => new DrugStore(drugNetwork, number, address);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}