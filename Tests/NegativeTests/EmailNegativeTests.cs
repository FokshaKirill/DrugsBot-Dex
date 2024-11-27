using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности Email
/// </summary>
public class EmailNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности Email
    /// </summary>
    public static IEnumerable<object[]> TestEmailValidationExceptionData =
        NegativeTestsDataGenerator.GetEmailValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра Email
    /// </summary>
    /// <param name="value">Электронная почта.</param>
    [Theory]
    [MemberData(nameof(TestEmailValidationExceptionData))]
    public void Add_EmailProperties_ThrowValidationException(
        string value)
    {
        // Act
        var action = () => new Email(value);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}