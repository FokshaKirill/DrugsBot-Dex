using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности Drug
/// </summary>
public class DrugNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности Drug
    /// </summary>
    public static IEnumerable<object[]> TestDrugValidationExceptionData =
        NegativeTestsDataGenerator.GetDrugValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра Drug
    /// </summary>
    /// <param name="name">Название лекарства.</param>
    /// <param name="manufacturer">Производитель.</param>
    /// <param name="countryCodeId">Код страны.</param>
    /// <param name="country">Страна.</param>
    [Theory]
    [MemberData(nameof(TestDrugValidationExceptionData))]
    public void Add_DrugProperties_ThrowValidationException(string name, string manufacturer, string countryCodeId,
        Country country)
    {
        // Act
        var action = () => new Drug(name, manufacturer, countryCodeId, country);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}