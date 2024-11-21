using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности Country
/// </summary>
public class CountryNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности Country
    /// </summary>
    public static IEnumerable<object[]> TestCountryValidationExceptionData =
        NegativeTestsDataGenerator.GetCountryValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра Country
    /// </summary>
    /// <param name="name">Название лекарства.</param>
    /// <param name="code">Производитель.</param>
    [Theory]
    [MemberData(nameof(TestCountryValidationExceptionData))]
    public void Add_CountryProperties_ThrowValidationException(string name, string code)
    {
        // Act
        var action = () => new Country(name, code);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}