using Backend.Application.Contracts;
using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface IProductService
{
    Task<Product> CreateAsync(Guid sellerId, CreateProductRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(Guid sellerId, Guid productId, UpdateProductRequest request, CancellationToken cancellationToken);
    Task ChangeStockAsync(Guid sellerId, Guid productId, int stock, CancellationToken cancellationToken);
    Task SetActiveAsync(Guid sellerId, Guid productId, bool isActive,CancellationToken cancellationToken);
    Task<IReadOnlyList<Product>> GetCatalogAsync(int skip, int take, CancellationToken cancellationToken);
}