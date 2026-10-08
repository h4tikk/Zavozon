using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface ICartService
{
    Task<Cart> GetAsync(Guid userId, CancellationToken cancellationToken);
    Task AddItemAsync(Guid userId, Guid productId, int quantity, CancellationToken cancellationToken);
    Task ChangeQuantityAsync(Guid userId, Guid productId, int newQuantity, CancellationToken cancellationToken);
    Task RemoveItemAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
    Task ClearAsync(Guid userId, CancellationToken cancellationToken);
}