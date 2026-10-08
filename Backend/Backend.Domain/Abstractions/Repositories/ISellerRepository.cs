using Backend.Model.Models;

namespace Backend.Model.Abstractions.Repositories;

public interface ISellerRepository
{
    Task<Seller?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Seller?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Seller>> GetPendingReviewAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task AddAsync(Seller seller, CancellationToken cancellationToken = default);
}
