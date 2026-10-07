using Backend.Model.Models;

namespace Backend.Model.Abstractions;

public interface IPaymentClaimRepository
{
    Task<PaymentClaim?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PaymentClaim?> GetByPurchaseIdAsync(Guid purchaseId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PaymentClaim>> GetPendingReviewAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PaymentClaim>> GetSellerAccessClaimsAsync(
        Guid sellerId,
        CancellationToken cancellationToken = default);
    Task AddAsync(PaymentClaim paymentClaim, CancellationToken cancellationToken = default);
}
