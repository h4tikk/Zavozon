using Backend.Model.Extensions;

namespace Backend.Model.Models;

public class PickUpPoint : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public string ServerName { get; set; } = string.Empty;
    public string WorldName { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public PickUpPointStatus Status { get; set; } = PickUpPointStatus.PendingReview;

    public Guid OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    public Guid? ReviewerId { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public string? RejectionReason { get; set; }
    public string? SuspensionReason { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = [];
}
