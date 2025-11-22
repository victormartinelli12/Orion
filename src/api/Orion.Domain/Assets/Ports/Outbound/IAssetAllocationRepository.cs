using Orion.Domain.Assets.Entities;
using Orion.Domain.Assets.Enums;

namespace Orion.Domain.Assets.Ports.Outbound;

public interface IAssetAllocationRepository
{
    Task CreateAsync(AssetAllocation allocation);
    Task<AssetAllocation?> GetByIdAsync(Guid id);
    Task UpdateAsync(AssetAllocation allocation);
    Task<IEnumerable<AssetAllocation>> GetAllAsync(int skip, int take);
    Task<IEnumerable<AssetAllocation>> GetByEmployeeAsync(Guid employeeId);
    Task<AssetAllocation?> GetActiveForEmployeeByTypeAsync(Guid employeeId, EAssetType type);
}