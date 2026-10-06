using Backend.Model.Extensions;
namespace Backend.Model.Models;

public class Seller : BaseEntity
{
    public string StoreName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public SellerApprovalStatus ApprovalStatus { get; set; } = SellerApprovalStatus.PendingReview;

    public DateTime PaidUntil { get; set; }

    public Guid? ReviewerId { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public string? RejectionReason { get; set; }
    public string? SuspentionReason { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}
