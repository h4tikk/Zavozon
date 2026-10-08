using Backend.Model.Abstractions.Repositories;
using Backend.Model.Extensions;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class SellerRepository(MarketplaceDbContext dbContext) : ISellerRepository
{
    public Task<Seller?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Sellers
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public Task<Seller?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        dbContext.Sellers
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.UserId == userId, cancellationToken);

    public async Task<IReadOnlyList<Seller>> GetPendingReviewAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Sellers
            .AsNoTracking()
            .Include(s => s.User)
            .Where(s => s.ApprovalStatus == SellerApprovalStatus.PendingReview)
            .OrderBy(s => s.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(Seller seller, CancellationToken cancellationToken = default) =>
        await dbContext.Sellers.AddAsync(seller, cancellationToken);
}
