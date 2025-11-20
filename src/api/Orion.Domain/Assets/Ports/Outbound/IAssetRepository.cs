using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Outbound;

public interface IAssetRepository
{
    Task Create(Asset asset);
    Task<Asset?> GetByIdAsync(Guid id);
    Task Update(Asset asset);
    Task<Asset?> GetBySerialNumberAsync(string serialNumber);
    Task<IEnumerable<Asset>> GetAllAsync(int skip, int take);
    Task<IQueryable<Asset>> GetWithWarrentyEndingAsync();
    Task<IQueryable<Asset>> GetInStockAsync();
}