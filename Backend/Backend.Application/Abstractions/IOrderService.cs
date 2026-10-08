using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface IOrderService
{
    Task<IReadOnlyList<Order>> GetSellerOrdersAsync(Guid sellerId, int skip, int take,CancellationToken cancellationToken);
    Task AcceptAsync(Guid sellerId, Guid orderId, CancellationToken cancellationToken);
    Task MarkReadyForCourierAsync(Guid sellerId, Guid orderId, CancellationToken cancellationToken);
    Task CancelAsync(Guid sellerId, Guid orderId, string reason, CancellationToken cancellationToken);
}