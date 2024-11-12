namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// </summary>
    public class Drug : BaseEntity
    {
        public Drug(string name, string manufacturer, string countryCodeId, Country country)
        {
            Name = name;
            Manufacturer = manufacturer;
            CountryCodeId = countryCodeId;
            Country = country;
        }

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
        
        // Навигационное свойство для связи с объектом Country
        public Country Country { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        
        /// <summary>
        /// Коллекция ISO-кодов
        /// </summary>
        public static readonly HashSet<string> ValidCountryCodes =
        [
            "AR", "AT", "AU", "BE", "BR", "CA", "CH", "CN", 
            "CO", "DE", "DK", "EG", "ES", "FI", "FR", "GB", 
            "GR", "IN", "IT", "JP", "KR", "MX", "MY", "NG", 
            "NL", "NO", "PH", "PL", "PT", "RU", "SE", "SG", 
            "TH", "TR", "UA", "US", "ZA"
        ];
    }
}