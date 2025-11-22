using Microsoft.EntityFrameworkCore;
using Orion.Domain.Assets.Entities;
using Orion.Domain.Assets.Enums;
using Orion.Domain.Assets.Ports.Outbound;
using Orion.Infrastructure.Data.Context;

namespace Orion.Infrastructure.Repositories.Assets;

public class AssetAllocationRepository : IAssetAllocationRepository
{
    private readonly AppDbContext _context;

    public AssetAllocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(AssetAllocation allocation)
    {
        await _context.AssetAllocations.AddAsync(allocation);
    }

    public async Task<AssetAllocation?> GetByIdAsync(Guid id)
    {
        return await _context.AssetAllocations.FindAsync(id);
    }

    public async Task UpdateAsync(AssetAllocation allocation)
    {
        _context.AssetAllocations.Update(allocation);
    }

    public async Task<IEnumerable<AssetAllocation>> GetAllAsync(int skip, int take)
    {
        return await _context.AssetAllocations
            .Include(x => x.Asset)
            .Include(x => x.Employee)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<IEnumerable<AssetAllocation>> GetByEmployeeAsync(Guid employeeId)
    {
        return await _context.AssetAllocations
            .Where(x => x.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<AssetAllocation?> GetActiveForEmployeeByTypeAsync(Guid employeeId, EAssetType type)
    {
        return await _context.AssetAllocations
            .Include(x => x.Asset)
            .Where(x => x.EmployeeId == employeeId && x.Asset.Type == type)
            .FirstOrDefaultAsync();
    }
}