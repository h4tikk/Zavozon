using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.ConfigureBaseEntity();

        builder.Property(o => o.Status)
            .HasConversion<string>()
            .HasMaxLength(32);
        
        builder.Property(o => o.CourierAcceptedAt)
            .HasColumnType("timestamp with time zone");
        
        builder.Property(o => o.DeliveredByCourierAt)
            .HasColumnType("timestamp with time zone");
        
        builder.Property(o => o.ReceivedByUserAt)
            .HasColumnType("timestamp with time zone");

        builder.HasIndex(o => new { o.SellerId, o.Status });
        
        builder.HasIndex(o => new { o.CourierId, o.Status });

        builder.HasOne(o => o.Purchase)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.PurchaseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Seller)
            .WithMany()
            .HasForeignKey(o => o.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Courier)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CourierId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
