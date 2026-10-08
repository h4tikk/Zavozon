using Backend.Model.Abstractions.Repositories;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class PurchaseRepository(MarketplaceDbContext dbContext) : IPurchaseRepository
{
    public Task<Purchase?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Purchases
            .AsSplitQuery()
            .Include(p => p.PickUpPoint)
            .Include(p => p.PaymentClaim)
            .Include(p => p.Orders)
                .ThenInclude(o => o.Items)
            .Include(p => p.Orders)
                .ThenInclude(o => o.Seller)
            .Include(p => p.Orders)
                .ThenInclude(o => o.Courier)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Purchase>> GetByUserIdAsync(
        Guid userId,
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Purchases
            .AsNoTracking()
            .AsSplitQuery()
            .Include(p => p.PickUpPoint)
            .Include(p => p.PaymentClaim)
            .Include(p => p.Orders)
                .ThenInclude(o => o.Items)
            .Include(p => p.Orders)
                .ThenInclude(o => o.Seller)
            .Include(p => p.Orders)
                .ThenInclude(o => o.Courier)
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(Purchase purchase, CancellationToken cancellationToken = default) =>
        await dbContext.Purchases.AddAsync(purchase, cancellationToken);
}
