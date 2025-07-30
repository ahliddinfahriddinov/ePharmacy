using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
{
    public void Configure(EntityTypeBuilder<Pharmacy> builder)
    {
        builder.ToTable("Pharmacies");

        builder.HasKey(p => p.PharmacyId);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.PhoneNumber).HasMaxLength(20);
        builder.Property(p => p.Email).HasMaxLength(100);
        builder.Property(p => p.OpeningTime).IsRequired();
        builder.Property(p => p.ClosingTime).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.Rating).HasDefaultValue(0);
        builder.Property(p => p.ReviewCount).HasDefaultValue(0);

        builder.HasOne(p => p.Address)
               .WithOne(a => a.Pharmacy)
               .HasForeignKey<Pharmacy>(p => p.AddressId);

        builder.HasOne(p => p.User)
               .WithOne(u => u.Pharmacy)
               .HasForeignKey<Pharmacy>(p => p.UserId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.Orders)
               .WithOne(o => o.Pharmacy)
               .HasForeignKey(o => o.PharmacyId);

        builder.HasMany(p => p.CartItems)
               .WithOne(ci => ci.Pharmacy)
               .HasForeignKey(ci => ci.PharmacyId);

        builder.HasMany(p => p.PharmacyDrugs)
               .WithOne(pd => pd.Pharmacy)
               .HasForeignKey(pd => pd.PharmacyId);
    }
}
