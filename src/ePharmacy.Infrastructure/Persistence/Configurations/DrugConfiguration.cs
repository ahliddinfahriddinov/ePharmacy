using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable("Drugs");

        builder.HasKey(d => d.DrugId);

        builder.Property(d => d.Name).IsRequired().HasMaxLength(150);
        builder.Property(d => d.GenericName).HasMaxLength(150);
        builder.Property(d => d.Manufacturer).HasMaxLength(150);
        builder.Property(d => d.Description).HasMaxLength(1000);
        builder.Property(d => d.Category).IsRequired().HasConversion<string>().HasMaxLength(50);
        builder.Property(d => d.Dosage).HasMaxLength(100);
        builder.Property(d => d.ActiveIngredients).HasMaxLength(500);
        builder.Property(d => d.SideEffects).HasMaxLength(500);
        builder.Property(d => d.Contraindications).HasMaxLength(500);
        builder.Property(d => d.RequiresPrescription).IsRequired();
        builder.Property(d => d.ImageUrl).HasMaxLength(500);
        builder.Property(d => d.Barcode).HasMaxLength(100);

        builder.HasMany(d => d.CartItems)
               .WithOne(ci => ci.Drug)
               .HasForeignKey(ci => ci.DrugId);

        builder.HasMany(d => d.OrderItems)
               .WithOne(oi => oi.Drug)
               .HasForeignKey(oi => oi.DrugId);

        builder.HasMany(d => d.PharmacyDrugs)
               .WithOne(pd => pd.Drug)
               .HasForeignKey(pd => pd.DrugId);
    }
}
