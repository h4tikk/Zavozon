using Backend.Model.Extensions;

namespace Backend.Model.Models;

public class Purchase : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid PickUpPointId { get; set; }
    public PickUpPoint PickUpPoint { get; set; } = null!;

    public long ProductsAmount { get; set; }
    public long DeliveryAmount { get; set; }
    public long TotalAmount { get; set; }

    public PurchaseStatus Status { get; set; } = PurchaseStatus.AwaitingPayment;
    public DateTime PaymentExpiresAt { get; set; }

    public PaymentClaim? PaymentClaim { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
