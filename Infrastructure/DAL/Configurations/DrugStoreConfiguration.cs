using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

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
    }
}