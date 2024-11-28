using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для сущности FavoriteDrug.
/// Определяет настройки таблицы FavoriteDrug, ключи, свойства и связи.
/// </summary>
public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));

        builder.HasKey(x => x.Id);

        builder
            .HasOne<Drug>()
            .WithMany()
            .HasForeignKey(fd => fd.DrugId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(fd => fd.Profile)
            .WithMany(p => p.FavoriteDrugs)
            .HasForeignKey(fd => fd.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}