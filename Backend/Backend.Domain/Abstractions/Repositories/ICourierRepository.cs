using Backend.Model.Models;

namespace Backend.Model.Abstractions.Repositories;

public interface ICourierRepository
{
    Task<Courier?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Courier?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Courier>> GetAvailableAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
    Task AddAsync(Courier courier, CancellationToken cancellationToken = default);
}
