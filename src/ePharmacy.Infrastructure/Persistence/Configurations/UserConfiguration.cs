using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ePharmacy.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.LastName).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Role).IsRequired().HasConversion<string>();

        builder.HasMany(u => u.Addresses)
               .WithOne(a => a.User)
               .HasForeignKey(a => a.UserId);

        builder.HasMany(u => u.Orders)
               .WithOne(o => o.User)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Cards)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(u => u.Cart)
               .WithOne(c => c.User)
               .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(u => u.Pharmacy)
               .WithOne(p => p.User)
               .HasForeignKey<Pharmacy>(p => p.UserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
