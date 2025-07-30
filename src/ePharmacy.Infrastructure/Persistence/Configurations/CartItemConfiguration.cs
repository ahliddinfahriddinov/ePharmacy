using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

        builder.HasKey(ci => ci.CartItemId);

        builder.Property(ci => ci.Quantity).IsRequired();
        builder.Property(ci => ci.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(ci => ci.Notes).HasMaxLength(500);

        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId);

        builder.HasOne(ci => ci.Pharmacy)
            .WithMany(p => p.CartItems)
            .HasForeignKey(ci => ci.PharmacyId);

        builder.HasOne(ci => ci.Drug)
            .WithMany(d => d.CartItems)
            .HasForeignKey(ci => ci.DrugId);
    }
}
