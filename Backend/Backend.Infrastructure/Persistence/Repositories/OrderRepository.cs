using Backend.Model.Abstractions;
using Backend.Model.Extensions;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class OrderRepository(MarketplaceDbContext dbContext) : IOrderRepository
{
    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Orders
            .AsSplitQuery()
            .Include(x => x.Items)
            .Include(x => x.Seller)
            .Include(x => x.Courier)
            .Include(x => x.Purchase)
                .ThenInclude(x => x.PickUpPoint)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Order>> GetBySellerIdAsync(
        Guid sellerId,
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Orders
            .AsNoTracking()
            .AsSplitQuery()
            .Include(o => o.Items)
            .Include(o => o.Courier)
            .Include(o => o.Purchase)
                .ThenInclude(p => p.PickUpPoint)
            .Where(o => o.SellerId == sellerId)
            .OrderByDescending(o => o.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Order>> GetAvailableForCourierAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Orders
            .AsNoTracking()
            .Include(o => o.Seller)
            .Include(o => o.Purchase)
                .ThenInclude(p => p.PickUpPoint)
            .Where(o => o.Status == OrderStatus.ReadyForCourier && o.CourierId == null)
            .OrderBy(o => o.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Order>> GetByCourierIdAsync(
        Guid courierId,
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Orders
            .AsNoTracking()
            .AsSplitQuery()
            .Include(o => o.Items)
            .Include(o => o.Seller)
            .Include(o => o.Purchase)
                .ThenInclude(p => p.PickUpPoint)
            .Where(o => o.CourierId == courierId)
            .OrderByDescending(o => o.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<bool> TryAssignCourierAsync(
        Guid orderId,
        Guid courierId,
        DateTime acceptedAtUtc,
        CancellationToken cancellationToken = default)
    {
        var affectedRows = await dbContext.Orders
            .Where(o =>
                o.Id == orderId &&
                o.Status == OrderStatus.ReadyForCourier &&
                o.CourierId == null)
            .ExecuteUpdateAsync(
                setters => setters
                    .SetProperty(o => o.CourierId, courierId)
                    .SetProperty(o => o.CourierAcceptedAt, acceptedAtUtc)
                    .SetProperty(o => o.Status, OrderStatus.InTransit)
                    .SetProperty(o => o.UpdatedAt, acceptedAtUtc),
                cancellationToken);

        return affectedRows == 1;
    }
}
