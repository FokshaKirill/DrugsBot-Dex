using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using Tests.Generators;

namespace Tests.NegativeTests;

/// <summary>
/// Негативные тесты для сущности Address
/// </summary>
public class AddressNegativeTests
{
    /// <summary>
    /// Коллекция ошибок при тестировании сущности Address
    /// </summary>
    public static IEnumerable<object[]> TestAddressValidationExceptionData =
        NegativeTestsDataGenerator.GetAddressValidationExceptionProperties();

    /// <summary>
    /// Проверка на выброс ошибки у экземпляра Address
    /// </summary>
    /// <param name="city"></param>
    /// <param name="street"></param>
    /// <param name="house"></param>
    /// <param name="postalCode"></param>
    [Theory]
    [MemberData(nameof(TestAddressValidationExceptionData))]
    public void Add_AddressProperties_ThrowValidationException(string city,
        string street,
        int house,
        int postalCode)
    {
        // Act
        var action = () => new Address(city, street, house, postalCode);

        // Assert
        action.Should().Throw<ValidationException>();
    }
}