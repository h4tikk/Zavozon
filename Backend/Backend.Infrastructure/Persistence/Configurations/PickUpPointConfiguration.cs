using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

internal sealed class PickUpPointConfiguration : IEntityTypeConfiguration<PickUpPoint>
{
    public void Configure(EntityTypeBuilder<PickUpPoint> builder)
    {
        builder.ToTable("pick_up_points");
        builder.ConfigureBaseEntity();

        builder.Property(pup => pup.Name)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(pup => pup.Description)
            .HasMaxLength(2000);
        
        builder.Property(pup => pup.ServerName)
            .HasMaxLength(64)
            .IsRequired();
        
        builder.Property(pup => pup.WorldName)
            .HasMaxLength(64)
            .IsRequired();
        
        builder.Property(pup => pup.Status)
            .HasConversion<string>()
            .HasMaxLength(32);
        builder.Property(pup => pup.ReviewedAt)
            .HasColumnType("timestamp with time zone");
        
        builder.Property(pup => pup.RejectionReason)
            .HasMaxLength(1000);
        
        builder.Property(pup => pup.SuspensionReason)
            .HasMaxLength(1000);

        builder.HasIndex(pup => pup.OwnerId);
        builder.HasIndex(pup => pup.Status);

        builder.HasOne(pup => pup.Owner)
            .WithMany(u => u.PickUpPoints)
            .HasForeignKey(pup => pup.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(pup => pup.ReviewerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
