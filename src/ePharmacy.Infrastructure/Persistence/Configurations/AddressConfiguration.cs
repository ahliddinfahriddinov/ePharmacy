using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.AddressId);

        builder.Property(a => a.Street)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(a => a.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.State)
               .HasMaxLength(100);

        builder.Property(a => a.PostalCode)
               .HasMaxLength(20);

        builder.Property(a => a.Country)
               .HasMaxLength(100);

        builder.Property(a => a.Latitude)
               .HasColumnType("decimal(9,6)");

        builder.Property(a => a.Longitude)
               .HasColumnType("decimal(9,6)");

        builder.HasOne(a => a.User)
               .WithMany(u => u.Addresses)
               .HasForeignKey(a => a.UserId);

        builder.HasOne(a => a.Pharmacy)
               .WithOne(p => p.Address)
               .HasForeignKey<Pharmacy>(p => p.AddressId);
    }
}
