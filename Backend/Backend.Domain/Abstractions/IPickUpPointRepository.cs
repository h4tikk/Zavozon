using Backend.Model.Models;

namespace Backend.Model.Abstractions;

public interface IPickUpPointRepository
{
    Task<PickUpPoint?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PickUpPoint>> GetActiveAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PickUpPoint>> GetByOwnerIdAsync(
        Guid ownerId,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PickUpPoint>> GetPendingReviewAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task AddAsync(PickUpPoint pickUpPoint, CancellationToken cancellationToken = default);
}
