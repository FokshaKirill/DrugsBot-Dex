using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

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

        builder.Property(x => x.Drug)
            .IsRequired();

        builder.Property(x => x.DrugId)
            .IsRequired();

        builder.Property(x => x.DrugStore)
            .IsRequired();

        builder.Property(x => x.DrugStoreId)
            .IsRequired();
    }
}