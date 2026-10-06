using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

internal sealed class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("sellers");
        builder.ConfigureBaseEntity();

        builder.Property(s => s.StoreName)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(s => s.Description)
            .HasMaxLength(2000);
        
        builder.Property(s => s.ApprovalStatus)
            .HasConversion<string>()
            .HasMaxLength(32);
        
        builder.Property(s => s.PaidUntil)
            .HasColumnType("timestamp with time zone");
        
        builder.Property(s => s.ReviewedAt)
            .HasColumnType("timestamp with time zone");
        
        builder.Property(s => s.RejectionReason)
            .HasMaxLength(1000);
        
        builder.Property(s => s.SuspentionReason)
            .HasMaxLength(1000);

        builder.HasIndex(s => s.UserId).IsUnique();
        builder.HasIndex(s => s.StoreName).IsUnique();

        builder.HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<Seller>(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.ReviewerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
