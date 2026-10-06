namespace Backend.Model.Extensions;

public enum OrderStatus
{
    AwaitingPayment,
    Paid,
    AcceptedBySeller,
    Packing,
    ReadyForCourier,
    InTransit,
    DeliveredByCourier,
    ReadyForPickUp,
    Received,
    Cancelled,
    Disputed
}
