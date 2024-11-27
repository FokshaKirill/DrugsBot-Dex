using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности Profile
/// </summary>
public class ProfileNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности Profile
    /// </summary>
    public static IEnumerable<object[]> TestProfileValidationExceptionData =
        NegativeTestsDataGenerator.GetProfileValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра Profile
    /// </summary>
    /// <param name="externalId">Внешний идентификатор телеграма.</param>
    /// <param name="email">Электронная почта.</param>
    [Theory]
    [MemberData(nameof(TestProfileValidationExceptionData))]
    public void Add_ProfileProperties_ThrowValidationException(
        string externalId,
        Email email)
    {
        // Act
        var action = () => new Profile(externalId, email);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}