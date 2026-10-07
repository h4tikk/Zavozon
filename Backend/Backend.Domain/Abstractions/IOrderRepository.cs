using Backend.Model.Models;

namespace Backend.Model.Abstractions;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Order>> GetBySellerIdAsync(
        Guid sellerId,
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Order>> GetAvailableForCourierAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Order>> GetByCourierIdAsync(
        Guid courierId,
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task<bool> TryAssignCourierAsync(
        Guid orderId,
        Guid courierId,
        DateTime acceptedAtUtc,
        CancellationToken cancellationToken = default);
}
