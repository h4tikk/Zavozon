using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.ConfigureBaseEntity();

        builder.Property(u => u.MinecraftNickname)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(u => u.TelegramUsername)
            .HasMaxLength(64);
        builder.Property(u => u.AvatarPath)
            .HasMaxLength(512);
        
        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(32);

        builder.HasIndex(u => u.TelegramUserId)
            .IsUnique();
        
        builder.HasIndex(x => x.MinecraftNickname)
            .IsUnique();
    }
}
