using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.History;

public interface IGetReportByMonth
{
    Task<IEnumerable<AssetAllocation>> ExecuteAsync(int month, int year);
}