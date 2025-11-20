using Orion.Domain.Abstraction;
using Orion.Domain.Assets.Enums;
using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Assets.Entities;

public class AssetHistory : Entity
{
    public Guid AssetId { get; init; }
    public virtual Asset Asset { get; }

    public Guid EmployeeId { get; init; }
    public virtual Employee Employee  { get; }

    public EAssetStatus OldStatus { get; init; }
    public EAssetStatus NewStatus { get; init; }
    public DateTime ChangedAt { get; init; }
    
    private AssetHistory() { }

    public static Result<AssetHistory> Create(Guid assetId, Guid employeeId,
        EAssetStatus oldStatus, EAssetStatus newStatus, DateTime changedAt)
    {
        if (assetId == Guid.Empty)
            return Result<AssetHistory>.Failure(new Error("AssetId.Error", "Asset ID cannot be empty"));
        
        if (employeeId == Guid.Empty)
            return Result<AssetHistory>.Failure(new Error("EmployeeId.Error", "Employee ID cannot be empty"));

        if (oldStatus == newStatus)
            return Result<AssetHistory>.Failure(new Error("Invalid.Status", "Cannot update status to the same."));

        return new AssetHistory
        {
            Id = Guid.NewGuid(),
            AssetId = assetId,
            EmployeeId = employeeId,
            OldStatus = oldStatus,
            NewStatus = newStatus,
            ChangedAt = changedAt,
            CreatedAt = DateTime.UtcNow
        };
    }
}