using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для сущности DrugItem.
/// Определяет настройки таблицы DrugItem, ключи, свойства и связи.
/// </summary>
public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Cost)
            .IsRequired()
            .HasPrecision(65, 2);

        builder.Property(x => x.Count)
            .IsRequired();

        builder
            .HasOne(x => x.Drug)
            .WithMany(d => d.DrugItems)
            .HasForeignKey(x => x.DrugId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.DrugStore)
            .WithMany(ds => ds.DrugItems)
            .HasForeignKey(x => x.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}