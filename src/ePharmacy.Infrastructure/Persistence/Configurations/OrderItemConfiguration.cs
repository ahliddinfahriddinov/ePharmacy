using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(oi => oi.OrderItemId);

        builder.Property(oi => oi.Quantity).IsRequired();
        builder.Property(oi => oi.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(oi => oi.Instructions).HasMaxLength(500);

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        builder.HasOne(oi => oi.Drug)
            .WithMany(d => d.OrderItems)
            .HasForeignKey(oi => oi.DrugId);
    }
}
