using Backend.Model.Models;

namespace Backend.Model.Abstractions.Repositories;

public interface IPurchaseRepository
{
    Task<Purchase?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Purchase>> GetByUserIdAsync(
        Guid userId,
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task AddAsync(Purchase purchase, CancellationToken cancellationToken = default);
}
