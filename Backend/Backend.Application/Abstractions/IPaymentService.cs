using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface IPaymentService
{
    Task SubmitTransferAsync(Guid userId, Guid paymentClaimId, long claimAmount,Guid transferId, CancellationToken cancellationToken);
    Task<IReadOnlyList<PaymentClaim>> GetPendingReviewsAsync(int skip, int take, CancellationToken cancellationToken);
    Task ApprovePurchasePaymentAsync(Guid purchaseId, Guid adminId, CancellationToken cancellationToken);
    Task ApproveSellerAccessPaymentAsync(Guid purchaseId, Guid sellerId, Guid adminId, CancellationToken cancellationToken);
    Task RejectAsync(Guid paymentClaimId, Guid adminId, string reason, CancellationToken cancellationToken);
}