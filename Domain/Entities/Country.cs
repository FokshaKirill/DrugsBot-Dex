using Domain.DomainEvents;
using Domain.Validation.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity<Country>
    {
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// </summary>
        /// <param name="name">Название страны.</param>
        /// <param name="code">Код страны.</param>
        public Country(string name, string code)
        {
            Name = name;
            Code = code;

            ValidateEntity(new CountryValidator());
        }

        #region Свойства

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Навигационное свойство для связи с препаратами.
        /// </summary>
        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();

        /// <summary>
        /// Коллекция ISO-кодов
        /// </summary>
        public static readonly HashSet<string> ValidCountryCodes = new HashSet<string>
        {
            "AR", "AT", "AU", "BE", "BR", "CA", "CH", "CN",
            "CO", "DE", "DK", "EG", "ES", "FI", "FR", "GB",
            "GR", "IN", "IT", "JP", "KR", "MX", "MY", "NG",
            "NL", "NO", "PH", "PL", "PT", "RU", "SE", "SG",
            "TH", "TR", "UA", "US", "ZA"
        };

        #endregion

        #region Методы

        /// <summary>
        /// Обновить название страны.
        /// </summary>
        /// <param name="name">Новое название страны.</param>
        public void UpdateName(string name)
        {
            if (Name != name)
            {
                var previousName = Name;
                Name = name;

                ValidateEntity(new CountryValidator());

                AddDomainEvent(new CountryUpdatedEvent(this, previousName, name));
            }
        }

        /// <summary>
        /// Обновить код страны.
        /// </summary>
        /// <param name="code">Новый код страны.</param>
        public void UpdateCode(string code)
        {
            if (!ValidCountryCodes.Contains(code))
                throw new ArgumentException("Неверный код страны.", nameof(code));

            if (Code != code)
            {
                var previousCode = Code;
                Code = code;

                ValidateEntity(new CountryValidator());

                AddDomainEvent(new CountryUpdatedEvent(this, previousCode, code));
            }
        }

        #endregion
    }
}