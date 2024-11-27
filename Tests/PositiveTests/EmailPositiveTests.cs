using Bogus;
using Domain.ValueObjects;
using FluentAssertions;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности Email
/// </summary>
public class EmailPositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности Email
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра Email
    /// </summary>
    [Fact]
    public void Add_Email_ReturnNewEmail()
    {
        // Arrange
        var value = _faker.Internet.Email();

        // Act
        var email = new Email(value);

        // Assert
        email.Value.Should().Be(value);
    }
}