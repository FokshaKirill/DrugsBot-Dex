using Domain.Entities;
using Infrastructure.DAL.Configurations;
using Infrastructure.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.DAL;

/// <summary>
/// Контекст базы данных для управления данными приложения DrugsBot.
/// Содержит DbSet для каждой из сущностей и настройки конфигурации.
/// </summary>
public class DrugsBotDbContext : DbContext
{
    private readonly DatabaseSettings _options;

    /// <summary>
    /// Создает экземпляр <see cref="DrugsBotDbContext"/> с указанными параметрами.
    /// </summary>
    /// <param name="options">Параметры конфигурации контекста базы данных.</param>
    public DrugsBotDbContext(IOptions<DatabaseSettings> options)
    {
        _options = options.Value;
    }

    /// <summary>
    /// Таблица лекарств.
    /// Используется для хранения данных о лекарствах.
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }

    /// <summary>
    /// Таблица товаров.
    /// Содержит данные о конкретных партиях лекарств в аптеках.
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; set; }

    /// <summary>
    /// Таблица избранных лекарств.
    /// Используется для хранения информации о лекарствах, добавленных пользователями в избранное.
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }

    /// <summary>
    /// Таблица стран.
    /// Хранит данные о странах, связанных с производителями лекарств.
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Таблица профилей.
    /// Содержит данные о профилях пользователей.
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }

    /// <summary>
    /// Таблица аптек.
    /// Используется для хранения информации об аптеках и их принадлежности к аптечным сетям.
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; set; }

    /// <summary>
    /// Метод конфигурации модели базы данных.
    /// Автоматически применяет все конфигурации, определенные в текущей сборке.
    /// </summary>
    /// <param name="modelBuilder">Строитель моделей для настройки сущностей базы данных.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_options.ConnectionString,
            (options) => { options.CommandTimeout(_options.CommandTimeout); });
    }
}