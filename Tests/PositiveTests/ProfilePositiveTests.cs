using Bogus;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности Profile
/// </summary>
public class ProfilePositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности Profile
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра Profile
    /// </summary>
    [Fact]
    public void Add_Profile_ReturnNewProfile()
    {
        // Arrange
        var externalId = _faker.Random.Int(1000000, 9999999).ToString();
        var email = new Email(_faker.Internet.Email());

        // Act
        var profile = new Profile(externalId, email);

        // Assert
        profile.ExternalId.Should().Be(externalId);
        profile.Email.Should().Be(email);
    }
}