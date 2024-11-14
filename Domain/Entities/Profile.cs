namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// </summary>
    public class Profile : BaseEntity<Profile>
    {
        public Profile(Guid id, string externalid, List<FavoriteDrug> favoriteDrugs, string? email)
        {
            Id = id;
            Externalid = externalid;
            Email = email;
            FavoriteDrugs = favoriteDrugs;
        }
        
        /// <summary>
        /// Идентификатор профиля.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Идентификатор профиля Telegram.
        /// </summary>
        public string Externalid { get; private set; }
        
        /// <summary>
        /// Коллекция избранных лекарств.
        /// </summary>
        public List<FavoriteDrug> FavoriteDrugs { get; private set; }
        
        // Навигационное свойство для связи с объектом Country
        public string? Email { get; private set; }
    }
}