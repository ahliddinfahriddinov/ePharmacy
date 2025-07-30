using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards");
        builder.HasKey(c => c.CardId);

        builder.Property(c => c.CardHolderName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.CardNumber)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(c => c.ExpiryMonth)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(c => c.ExpiryYear)
               .IsRequired()
               .HasMaxLength(4);

        builder.Property(c => c.CVV)
               .IsRequired(false)
               .HasMaxLength(4);

        builder.Property(c => c.CardType)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(20);

        builder.Property(c => c.IsDefault)
               .IsRequired();

        builder.Property(c => c.IsActive)
               .IsRequired();

        builder.HasOne(c => c.User)
               .WithMany(u => u.Cards)
               .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
    }
}
