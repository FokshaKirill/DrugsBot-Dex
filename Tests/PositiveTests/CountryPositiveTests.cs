﻿using Bogus;
using Domain.Entities;
using FluentAssertions;

namespace Tests.PositiveTests;

/// <summary>
/// Позитивные тесты для сущности Country
/// </summary>
public class CountryPositiveTests
{
    /// <summary>
    /// Генератор фальшивых данных для сущности Country
    /// </summary>
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка на правильное создание экземпляра Country
    /// </summary>
    [Fact]
    public void Add_Country_ReturnNewCountry()
    {
        // Arrange
        var name = _faker.Random.String2(2);
        var code = _faker.PickRandom(Country.ValidCountryCodes.ToList());

        // Act
        var country = new Country(name, code);

        // Assert
        country.Name.Should().Be(name);
        country.Code.Should().Be(code);
    }
}