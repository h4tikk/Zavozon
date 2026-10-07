using Backend.Model.Abstractions;
using Backend.Model.Extensions;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class ProductRepository(MarketplaceDbContext dbContext) : IProductRepository
{
    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Products
            .Include(p => p.Seller)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Product>> GetByIdsAsync(
        IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default) =>
        await dbContext.Products
            .Include(p => p.Seller)
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Product>> GetCatalogAsync(
        DateTime utcNow,
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Products
            .AsNoTracking()
            .Include(p => p.Seller)
            .Where(p =>
                p.IsActive &&
                p.Stock > 0 &&
                p.Seller.ApprovalStatus == SellerApprovalStatus.Approved &&
                p.Seller.PaidUntil > utcNow)
            .OrderByDescending(p => p.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Product>> GetBySellerIdAsync(
        Guid sellerId,
        CancellationToken cancellationToken = default) =>
        await dbContext.Products
            .AsNoTracking()
            .Where(p => p.SellerId == sellerId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default) =>
        await dbContext.Products.AddAsync(product, cancellationToken);
}
