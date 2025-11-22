using Microsoft.EntityFrameworkCore;
using Orion.Domain.Assets.Entities;
using Orion.Domain.Assets.Enums;
using Orion.Domain.Assets.Ports.Outbound;
using Orion.Infrastructure.Data.Context;

namespace Orion.Infrastructure.Repositories.Assets;

public class AssetRepository :  IAssetRepository
{
    private readonly AppDbContext _context;
    
    public AssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Asset asset)
    {
        await _context.Assets.AddAsync(asset);
    }

    public async Task<Asset?> GetByIdAsync(Guid id)
    {
        return await _context.Assets.FindAsync(id);
    }

    public async Task Update(Asset asset)
    {
        _context.Assets.Update(asset);
    }

    public async Task<Asset?> GetBySerialNumberAsync(string serialNumber)
    {
        return  await _context
            .Assets
            .FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
    }

    public async Task<IEnumerable<Asset>> GetAllAsync(int skip, int take)
    {
        return await _context.Assets
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IQueryable<Asset>> GetWithWarrentyEndingAsync()
    {
        return _context.Assets
            .Where(x => x.WarrentyEndDate <= DateTime.UtcNow.Date.AddDays(30));
    }

    public async Task<IQueryable<Asset>> GetInStockAsync()
    {
        return _context.Assets
            .Where(x => x.Status == EAssetStatus.InStock);
    }
}