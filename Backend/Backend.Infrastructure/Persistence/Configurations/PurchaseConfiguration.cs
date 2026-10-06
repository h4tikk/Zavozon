using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

internal sealed class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("purchases");
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Status)
            .HasConversion<string>()
            .HasMaxLength(32);
        
        builder.Property(p => p.PaymentExpiresAt)
            .HasColumnType("timestamp with time zone");

        builder.HasIndex(p => new { p.UserId, p.Status });

        builder.HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PickUpPoint)
            .WithMany(p => p.Purchases)
            .HasForeignKey(p => p.PickUpPointId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
