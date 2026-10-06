namespace Backend.Model.Models;

public class Courier : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public bool IsAvailable { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
}
