using Backend.Model.Abstractions.Repositories;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class CourierRepository(MarketplaceDbContext dbContext) : ICourierRepository
{
    public Task<Courier?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Couriers
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task<Courier?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        dbContext.Couriers
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

    public async Task<IReadOnlyList<Courier>> GetAvailableAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.Couriers
            .AsNoTracking()
            .Include(c => c.User)
            .Where(c => c.IsAvailable)
            .OrderBy(c => c.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(Courier courier, CancellationToken cancellationToken = default) =>
        await dbContext.Couriers.AddAsync(courier, cancellationToken);
}
