using Backend.Model.Models;

namespace Backend.Model.Abstractions.Repositories;

public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddAsync(Cart cart, CancellationToken cancellationToken = default);
    void RemoveItem(CartItem cartItem);
    void Clear(Cart cart);
}
