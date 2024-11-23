using Domain.Validation.Validators;

namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity<Drug>
{
    public Drug(string name, string manufacturer, string countryCodeId, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;

        ValidateEntity(new DrugValidator());
    }

    public Drug(string name, string manufacturer, string countryCodeId, Country country, List<DrugItem> drugItems)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        DrugItems = drugItems;

        ValidateEntity(new DrugValidator());
    }

    #region Свойства

    /// <summary>
    /// Название препарата.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Производитель препарата.
    /// </summary>
    public string Manufacturer { get; private set; }

    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string CountryCodeId { get; private set; }

    /// <summary>
    /// Связь с объектом Country.
    /// </summary>
    public Country Country { get; private set; }

    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();

    #endregion

    #region Методы

    // Метод для обновления имени
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    // Метод для обновления производителя
    public void UpdateManufacturer(string manufacturer)
    {
        if (string.IsNullOrWhiteSpace(manufacturer))
        {
            throw new ArgumentException("Manufacturer cannot be null or whitespace.", nameof(manufacturer));
        }

        Manufacturer = manufacturer;
    }

    // Метод для обновления кода страны
    public void UpdateCountryCode(string countryCodeId)
    {
        if (string.IsNullOrWhiteSpace(countryCodeId))
        {
            throw new ArgumentException("CountryCodeId cannot be null or whitespace.", nameof(countryCodeId));
        }

        CountryCodeId = countryCodeId;
    }

    // Метод для обновления страны
    public void UpdateCountry(Country country)
    {
        if (country == null)
        {
            throw new ArgumentNullException(nameof(country), "Country cannot be null.");
        }

        Country = country;
    }

    // Метод для обновления коллекции DrugItems
    public void UpdateDrugItems(ICollection<DrugItem> drugItems)
    {
        if (drugItems == null || !drugItems.Any())
        {
            throw new ArgumentException("DrugItems cannot be null or empty.", nameof(drugItems));
        }

        DrugItems = drugItems.ToList();
    }

    #endregion
}