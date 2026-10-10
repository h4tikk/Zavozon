using Backend.Application.Abstractions;
using Backend.Model.Abstractions.Repositories;
using Backend.Model.Extensions;
using Backend.Model.Models;

namespace Backend.Application.Services;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SellerService(ISellerRepository sellerRepository,  IUnitOfWork unitOfWork)
    {
        _sellerRepository = sellerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Seller> ApplyAsync(Guid userId, string storeName, string? description, CancellationToken cancellationToken)
    { 
        if(string.IsNullOrEmpty(storeName)) 
            throw new ArgumentNullException(nameof(storeName));
        
        var seller = await _sellerRepository.GetByIdAsync(userId, cancellationToken);
        if (seller is not null) 
            throw new InvalidOperationException($"Seller with id {userId} already exists");
        var newSeller = new Seller
        {
            Id = Guid.NewGuid(),
            StoreName = storeName,
            Description = description,
            PaidUntil = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            ApprovalStatus = SellerApprovalStatus.PendingReview
        }; 
        await _sellerRepository.AddAsync(newSeller, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return newSeller;
    }
    
    public async Task<Seller?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _sellerRepository.GetByUserIdAsync(userId, cancellationToken);
    }

    public async Task ApproveAsync(Guid userId, Guid adminId, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetByUserIdAsync(userId, cancellationToken);
        if (seller is null)
            throw new InvalidOperationException($"Seller with id {userId} not found");

        seller.ApprovalStatus = SellerApprovalStatus.Approved;
        seller.ReviewerId = adminId;
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task RejectAsync(Guid userId, Guid adminId, string reason, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetByUserIdAsync(userId, cancellationToken);
        if (seller is null)
            throw new InvalidOperationException($"Seller with id {userId} not found");
        
        seller.ApprovalStatus = SellerApprovalStatus.Rejected;
        seller.ReviewerId = adminId;
        seller.RejectionReason = reason ?? "Причина не указана";
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task SetPaidUntilAsync(Guid userId, Guid adminId, DateTime period, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetByUserIdAsync(userId, cancellationToken);
        if (seller is null)
            throw new InvalidOperationException($"Seller with id {userId} not found");
        if(period is null)
            
        seller.PaidUntil = period;
        
    }
}