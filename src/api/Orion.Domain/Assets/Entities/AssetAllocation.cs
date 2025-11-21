using Orion.Domain.Abstraction;
using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Assets.Entities;

public class AssetAllocation : Entity
{
    public Guid AssetId { get; init; }  
    public virtual Asset Asset { get; }

    public Guid EmployeeId { get; init; }
    public virtual Employee Employee { get; }

    public DateTime AllocationDate { get; init; } = DateTime.UtcNow.Date;
    public DateTime? DesallocationDate { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    private AssetAllocation() {}

    public void DesalocateAsset()
    {
        DesallocationDate = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<AssetAllocation> Create(Guid assetId, Guid employeeId)
    {
        if (assetId == Guid.Empty)
            return Result<AssetAllocation>.Failure(new Error("AssetId.Error", "Asset ID cannot be empty"));
        
        if (employeeId == Guid.Empty)
            return Result<AssetAllocation>.Failure(new Error("EmployeeId.Error", "Employee ID cannot be empty"));

        return new AssetAllocation
        {
            Id = Guid.NewGuid(),
            AssetId = assetId,
            EmployeeId = employeeId,
            CreatedAt =  DateTime.UtcNow,
        };
    }
}