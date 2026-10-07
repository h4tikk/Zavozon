using Backend.Model.Abstractions;
using Backend.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository(MarketplaceDbContext dbContext) : IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public Task<User?> GetByTelegramUserIdAsync(
        long telegramUserId,
        CancellationToken cancellationToken = default) =>
        dbContext.Users.FirstOrDefaultAsync(
            u => u.TelegramUserId == telegramUserId,
            cancellationToken);

    public Task<bool> NicknameExistsAsync(
        string nickname,
        CancellationToken cancellationToken = default) =>
        dbContext.Users.AnyAsync(u => u.Nickname == nickname, cancellationToken);

    public async Task AddAsync(User user, CancellationToken cancellationToken = default) =>
        await dbContext.Users.AddAsync(user, cancellationToken);
}
