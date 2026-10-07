using Backend.Model.Models;

namespace Backend.Model.Abstractions;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetByIdsAsync(
        IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetCatalogAsync(
        DateTime utcNow,
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Product>> GetBySellerIdAsync(
        Guid sellerId,
        CancellationToken cancellationToken = default);
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
}
