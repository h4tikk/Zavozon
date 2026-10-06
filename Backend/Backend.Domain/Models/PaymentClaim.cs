using Backend.Model.Extensions;

namespace Backend.Model.Models;

public class PaymentClaim : BaseEntity
{
    public PaymentPurpose Purpose { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid? PurchaseId { get; set; }
    public Purchase? Purchase { get; set; }

    public Guid? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public long ExpectedAmount { get; set; }
    public long ClaimedAmount { get; set; }

    public string PayerNickname { get; set; } = string.Empty;
    public string ReceiverNickname { get; set; } = string.Empty;
    public string? ScreenshotPath { get; set; }

    public PaymentClaimStatus Status { get; set; } = PaymentClaimStatus.AwaitingTransfer;

    public Guid? ReviewerId { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public string? RejectionReason { get; set; }
}
