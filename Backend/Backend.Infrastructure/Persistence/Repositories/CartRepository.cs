using Backend.Model.Abstractions.Repositories;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class CartRepository(MarketplaceDbContext dbContext) : ICartRepository
{
    public Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
        dbContext.Carts
            .AsSplitQuery()
            .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                    .ThenInclude(p => p.Seller)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

    public async Task AddAsync(Cart cart, CancellationToken cancellationToken = default) =>
        await dbContext.Carts.AddAsync(cart, cancellationToken);

    public void RemoveItem(CartItem cartItem) =>
        dbContext.CartItems.Remove(cartItem);

    public void Clear(Cart cart)
    {
        dbContext.CartItems.RemoveRange(cart.Items);
        cart.Items.Clear();
    }
}
