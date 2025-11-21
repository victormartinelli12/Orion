using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.History;

public interface IGetReportByEmployee
{
    Task<IEnumerable<AssetAllocation>> ExecuteAsync(Guid employeeId);
}