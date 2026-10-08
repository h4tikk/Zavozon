using Backend.Application.Contracts;
using Backend.Model.Models;

namespace Backend.Application.Abstractions;

public interface IPickUpPointAsync
{
    Task<PickUpPoint> CreateAsync(Guid ownerId, CreatePickUpPointRequest request, CancellationToken cancellationToken);
    Task<IReadOnlyList<PickUpPoint>> GetActiveAsync(int skip, int take, CancellationToken cancellationToken);
    Task<IReadOnlyList<PickUpPoint>> GetMyAsync(Guid ownerId, CancellationToken cancellationToken);
    Task ApproveAsync(Guid pickUpPointId, Guid adminId, CancellationToken cancellationToken);
    Task RejectAsync(Guid pickUpPointId, Guid adminId, CancellationToken cancellationToken);
    Task SuspendAsync(Guid pickUpPointId, Guid adminId, CancellationToken cancellationToken);
}