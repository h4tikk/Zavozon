using Backend.Model.Extensions;

namespace Backend.Model.Models;

public class Order : BaseEntity
{
    public Guid PurchaseId { get; set; }
    public Purchase Purchase { get; set; } = null!;

    public Guid SellerId { get; set; }
    public Seller Seller { get; set; } = null!;

    public Guid? CourierId { get; set; }
    public Courier? Courier { get; set; }

    public long ProductsAmount { get; set; }
    public long SellerReward { get; set; }
    public long CourierReward { get; set; }
    public long PickUpPointReward { get; set; }
    public long PlatformCommission { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.AwaitingPayment;

    public DateTime? CourierAcceptedAt { get; set; }
    public DateTime? DeliveredByCourierAt { get; set; }
    public DateTime? ReceivedByUserAt { get; set; }

    public ICollection<OrderItem> Items { get; set; } = [];
}
