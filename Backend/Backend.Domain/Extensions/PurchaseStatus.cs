namespace Backend.Model.Extensions;

public enum PurchaseStatus
{
    AwaitingPayment,
    PaymentReview,
    Paid,
    Processing,
    ReadyForPickUp,
    Completed,
    Expired,
    Cancelled,
    Disputed
}
