using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для сущности Drug.
/// Определяет настройки таблицы Drug, ключи, свойства и связи.
/// </summary>
public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasOne(d => d.Country)
            .WithMany(c => c.Drugs)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}