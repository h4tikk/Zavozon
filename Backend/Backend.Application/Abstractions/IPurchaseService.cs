using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface IPurchaseService
{
    Task<Purchase> GetAsync(Guid userId, Guid purchaseId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Purchase>> GetMyAsync(Guid userId, int skip, int take, CancellationToken cancellationToken);
    Task CancelAsync(Guid userId, Guid purchaseId, CancellationToken cancellationToken);
    Task OpenDisputeAsync(Guid userId, Guid purchaseId, string reason, CancellationToken cancellationToken);
}