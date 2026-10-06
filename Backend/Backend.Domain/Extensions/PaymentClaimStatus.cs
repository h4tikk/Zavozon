namespace Backend.Model.Extensions;

public enum PaymentClaimStatus
{
    AwaitingTransfer,
    PendingReview,
    Approved,
    Rejected,
    Expired,
    Cancelled
}
