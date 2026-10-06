namespace Backend.Model.Models;

public class Seller : BaseEntity
{
    public string StoreName { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public DateTime PaidTo { get; set; }
    
}