using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface ICheckoutService
{
    Task<Purchase> CheckoutAsync(Guid userId, Guid pickUpPointId, CancellationToken cancellationToken);
    Task ExpireAsync(Guid purchaseId, CancellationToken cancellationToken);
}