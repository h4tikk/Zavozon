using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface ISellerService
{
    Task<Seller> ApplyAsync(Guid userId, string storeName, string? description, CancellationToken cancellationToken);
    Task<Seller?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task ApproveAsync(Guid userId, Guid adminId, CancellationToken cancellationToken);
    Task RejectAsync(Guid userId, Guid adminId, string reason, CancellationToken cancellationToken);
    Task SetPaidUntilAsync(Guid userId, Guid adminId, DateTime period, CancellationToken cancellationToken);
}