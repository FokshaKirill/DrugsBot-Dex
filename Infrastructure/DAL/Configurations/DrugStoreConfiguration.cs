using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для сущности DrugStore.
/// Определяет настройки таблицы DrugStore, ключи, свойства и связи.
/// </summary>
public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Number)
            .IsRequired();

        builder.Property(x => x.Address)
            .IsRequired();

        builder
            .HasMany(ds => ds.DrugItems)
            .WithOne(di => di.DrugStore)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}