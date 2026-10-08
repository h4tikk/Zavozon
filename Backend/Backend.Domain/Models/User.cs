using Backend.Model.Extensions;
namespace Backend.Model.Models;

public class User : BaseEntity
{
    public string MinecraftNickname { get; set; } = string.Empty;
    
    public string? TelegramUsername { get; set; }  = string.Empty;
    public long TelegramUserId { get; set; } 
    
    public string? AvatarPath { get; set; }  = string.Empty;
    
    public UserStatus Status { get; set; } =  UserStatus.Active;
    
    public ICollection<PickUpPoint> PickUpPoints { get; set; } = [];
    public ICollection<Purchase> Purchases { get; set; } = [];
}