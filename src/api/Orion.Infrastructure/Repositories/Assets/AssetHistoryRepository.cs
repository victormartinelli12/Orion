using Microsoft.EntityFrameworkCore;
using Orion.Domain.Assets.Entities;
using Orion.Domain.Assets.Ports.Outbound;
using Orion.Infrastructure.Data.Context;

namespace Orion.Infrastructure.Repositories.Assets;

public class AssetHistoryRepository : IAssetHistoryRepository
{
    private readonly  AppDbContext _context;

    public AssetHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(AssetHistory allocation)
    {
        await _context.AssetHistories.AddAsync(allocation);
    }

    public async Task<IEnumerable<AssetHistory>> GetAllAsync(int skip, int take)
    {
        return await _context.AssetHistories
            .Include(x => x.Asset)
            .Include(x => x.Employee)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<IQueryable<AssetHistory>> GetChangedByMonthAsync(int month, int year)
    {
        return _context.AssetHistories
            .Where(x => x.ChangedAt.Month == month && x.ChangedAt.Year == year);
    }

    public async Task<IQueryable<AssetHistory>> GetByEmployeeAsync(Guid employeeId)
    {
        return _context.AssetHistories
            .Where(x => x.EmployeeId == employeeId);
    }
}