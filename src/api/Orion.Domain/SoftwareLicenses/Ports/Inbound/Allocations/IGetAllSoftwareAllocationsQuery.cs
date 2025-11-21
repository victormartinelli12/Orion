using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Allocations;

public interface IGetAllSoftwareAllocationsQuery
{
    Task<IEnumerable<SoftwareAllocation>> ExecuteAsync(int skip, int take);
}