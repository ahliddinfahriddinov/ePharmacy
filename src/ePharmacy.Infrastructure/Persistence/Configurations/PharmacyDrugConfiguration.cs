using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class PharmacyDrugConfiguration : IEntityTypeConfiguration<PharmacyDrug>
{
    public void Configure(EntityTypeBuilder<PharmacyDrug> builder)
    {
        builder.ToTable("PharmacyDrugs");

        builder.HasKey(pd => pd.PharmacyDrugId);

        builder.Property(pd => pd.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(pd => pd.StockQuantity).IsRequired();
        builder.Property(pd => pd.ExpiryDate).HasConversion<DateTime?>()
               .HasColumnType("datetime2")
               .IsRequired(false);
        builder.Property(pd => pd.IsAvailable).IsRequired();

        builder.HasOne(pd => pd.Pharmacy)
               .WithMany(p => p.PharmacyDrugs)
               .HasForeignKey(pd => pd.PharmacyId);

        builder.HasOne(pd => pd.Drug)
               .WithMany(d => d.PharmacyDrugs)
               .HasForeignKey(pd => pd.DrugId);
    }
}
