using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

internal sealed class PaymentClaimConfiguration : IEntityTypeConfiguration<PaymentClaim>
{
    public void Configure(EntityTypeBuilder<PaymentClaim> builder)
    {
        builder.ToTable("payment_claims");
        builder.ConfigureBaseEntity();

        builder.Property(pc => pc.Purpose)
            .HasConversion<string>()
            .HasMaxLength(32);
        
        builder.Property(pc => pc.Status)
            .HasConversion<string>()
            .HasMaxLength(32);
        
        builder.Property(pc => pc.PayerNickname)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(pc => pc.ReceiverNickname)
            .HasMaxLength(32)
            .IsRequired();
        
        builder.Property(pc => pc.ScreenshotPath)
            .HasMaxLength(512);
        
        builder.Property(pc => pc.ReviewedAt)
            .HasColumnType("timestamp with time zone");
        
        builder.Property(pc => pc.RejectionReason)
            .HasMaxLength(1000);

        builder.HasIndex(pc => pc.PurchaseId)
            .IsUnique();
        
        builder.HasIndex(pc => new { pc.SellerId, pc.Status });

        builder.HasOne(pc => pc.User)
            .WithMany()
            .HasForeignKey(pc => pc.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pc => pc.Purchase)
            .WithOne(p => p.PaymentClaim)
            .HasForeignKey<PaymentClaim>(pc => pc.PurchaseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.Seller)
            .WithMany()
            .HasForeignKey(pc => pc.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(pc => pc.ReviewerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
