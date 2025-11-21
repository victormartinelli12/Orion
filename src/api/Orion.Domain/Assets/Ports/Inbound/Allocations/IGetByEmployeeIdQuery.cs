using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Allocations;

public interface IGetByEmployeeIdQuery
{
    Task<IEnumerable<AssetAllocation>> ExecuteAsync(Guid employeeId);
}