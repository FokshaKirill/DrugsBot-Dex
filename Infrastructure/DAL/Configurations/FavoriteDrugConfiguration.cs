using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrugId)
            .IsRequired();

        builder.Property(x => x.Drug)
            .IsRequired();

        builder.Property(x => x.Profile)
            .IsRequired();

        builder.Property(x => x.ProfileId)
            .IsRequired();
    }
}