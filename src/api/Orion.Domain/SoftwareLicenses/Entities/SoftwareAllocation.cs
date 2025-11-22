using Orion.Domain.Abstraction;
using Orion.Domain.Abstraction.Entities;
using Orion.Domain.Abstraction.Responses;
using Orion.Domain.Employees.Entities;

namespace Orion.Domain.SoftwareLicenses.Entities;

public class SoftwareAllocation : Entity
{
    public Guid SoftwareLicenseId { get; init; }  
    public virtual SoftwareLicense SoftwareLicense { get; }

    public Guid EmployeeId { get; init; }
    public virtual Employee Employee { get; init; }

    public DateTime AllocationDate { get; init; } = DateTime.UtcNow;
    public DateTime? DesallocationDate { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    private SoftwareAllocation() { }

    public void DesallocateSoftware()
    {
        DesallocationDate = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Result<SoftwareAllocation> Create(Guid softwareLicenseId)
    {
        if (softwareLicenseId == Guid.Empty)
            return Result<SoftwareAllocation>.Failure(new Error("SoftwareId.Error", "Software ID cannot be null."));

        return new SoftwareAllocation
        {
            Id = Guid.NewGuid(),
            SoftwareLicenseId = softwareLicenseId,
            CreatedAt = DateTime.UtcNow
        };
    }
}