using Backend.Model.Abstractions.Repositories;
using Backend.Model.Extensions;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class PickUpPointRepository(MarketplaceDbContext dbContext) : IPickUpPointRepository
{
    public Task<PickUpPoint?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.PickUpPoints
            .Include(pup => pup.Owner)
            .FirstOrDefaultAsync(pup => pup.Id == id, cancellationToken);

    public async Task<IReadOnlyList<PickUpPoint>> GetActiveAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.PickUpPoints
            .AsNoTracking()
            .Include(pup => pup.Owner)
            .Where(pup => pup.Status == PickUpPointStatus.Active)
            .OrderBy(pup => pup.Name)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<PickUpPoint>> GetByOwnerIdAsync(
        Guid ownerId,
        CancellationToken cancellationToken = default) =>
        await dbContext.PickUpPoints
            .AsNoTracking()
            .Where(pup => pup.OwnerId == ownerId)
            .OrderByDescending(pup => pup.CreatedAt)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<PickUpPoint>> GetPendingReviewAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.PickUpPoints
            .AsNoTracking()
            .Include(pup => pup.Owner)
            .Where(pup => pup.Status == PickUpPointStatus.PendingReview)
            .OrderBy(pup => pup.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(PickUpPoint pickUpPoint, CancellationToken cancellationToken = default) =>
        await dbContext.PickUpPoints.AddAsync(pickUpPoint, cancellationToken);
}
