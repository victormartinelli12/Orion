using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Outbound;

public interface IAssetHistoryRepository
{
    Task CreateAsync(AssetHistory allocation);
    Task<IQueryable<AssetHistory>> GetChangedByMonthAsync(int month, int year);
    Task<IQueryable<AssetHistory>> GetByEmployeeAsync(Guid employeeId);
}