using Domain.Entities;
using Infrastructure.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

public class DrugsBotDbContext : DbContext
{
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Таблица лекарств.
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }

    /// <summary>
    /// Таблица товаров.
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; set; }

    /// <summary>
    /// Таблица избранных лекарств.
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }

    /// <summary>
    /// Таблица стран.
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Таблица профилей.
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }

    /// <summary>
    /// Таблица аптек.
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
    }
}