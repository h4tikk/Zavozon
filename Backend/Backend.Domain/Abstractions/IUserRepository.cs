using Backend.Model.Models;

namespace Backend.Model.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByTelegramUserIdAsync(long telegramUserId, CancellationToken cancellationToken = default);
    Task<bool> NicknameExistsAsync(string nickname, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}
