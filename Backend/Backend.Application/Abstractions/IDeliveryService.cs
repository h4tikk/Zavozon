using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface IDeliveryService
{
    Task<Courier> BecomeCourierAsync(Guid userId, CancellationToken cancellationToken);
    Task SetAvailability(Guid courierId, bool isAvailible, CancellationToken cancellationToken);
    Task<IReadOnlyList<Order>> GetAvailableOrders(CancellationToken cancellationToken);
    Task<bool> TakeOrderAsync(Guid courierId, Guid orderId, CancellationToken cancellationToken);
    Task MarkDeliveredAsync(Guid courierId, Guid orderId, CancellationToken cancellationToken);
    Task ConfirmReceivedAsync(Guid courierId, Guid orderId, CancellationToken cancellationToken);
}