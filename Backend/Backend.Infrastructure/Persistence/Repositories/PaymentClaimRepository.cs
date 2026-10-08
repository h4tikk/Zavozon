using Backend.Model.Abstractions.Repositories;
using Backend.Model.Extensions;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class PaymentClaimRepository(MarketplaceDbContext dbContext) : IPaymentClaimRepository
{
    public Task<PaymentClaim?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.PaymentClaims
            .Include(pc => pc.User)
            .Include(pc => pc.Purchase)
            .Include(pc => pc.Seller)
            .FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);

    public Task<PaymentClaim?> GetByPurchaseIdAsync(
        Guid purchaseId,
        CancellationToken cancellationToken = default) =>
        dbContext.PaymentClaims
            .Include(pc => pc.User)
            .FirstOrDefaultAsync(pc => pc.PurchaseId == purchaseId, cancellationToken);

    public async Task<IReadOnlyList<PaymentClaim>> GetPendingReviewAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default) =>
        await dbContext.PaymentClaims
            .AsNoTracking()
            .Include(pc => pc.User)
            .Include(pc => pc.Purchase)
            .Include(pc => pc.Seller)
            .Where(pc => pc.Status == PaymentClaimStatus.PendingReview)
            .OrderBy(pc => pc.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<PaymentClaim>> GetSellerAccessClaimsAsync(
        Guid sellerId,
        CancellationToken cancellationToken = default) =>
        await dbContext.PaymentClaims
            .AsNoTracking()
            .Where(pc => pc.SellerId == sellerId && pc.Purpose == PaymentPurpose.SellerAccess)
            .OrderByDescending(pc => pc.CreatedAt)
            .ToListAsync(cancellationToken);

    public async Task AddAsync(PaymentClaim paymentClaim, CancellationToken cancellationToken = default) =>
        await dbContext.PaymentClaims.AddAsync(paymentClaim, cancellationToken);
}
