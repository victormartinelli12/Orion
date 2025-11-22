using Microsoft.EntityFrameworkCore;
using Orion.Domain.SoftwareLicenses.Entities;
using Orion.Domain.SoftwareLicenses.Ports.Outbound;
using Orion.Infrastructure.Data.Context;

namespace Orion.Infrastructure.Repositories.SoftwaresLicenses;

public class SoftwareLicenseRepository  : ISoftwareLicenseRepository
{
    private readonly AppDbContext _context;

    public SoftwareLicenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(SoftwareLicense softwareLicense)
    {
        await _context.SoftwareLicenses.AddAsync(softwareLicense);
    }

    public async Task UpdateAsync(SoftwareLicense softwareLicense)
    {
        _context.SoftwareLicenses.Update(softwareLicense);
    }

    public async Task DeleteAsync(SoftwareLicense softwareLicense)
    {
        _context.SoftwareLicenses.Remove(softwareLicense);
    }

    public async Task<SoftwareLicense?> GetByIdAsync(Guid id)
    {
        return await  _context.SoftwareLicenses.FindAsync(id);
    }

    public async Task<SoftwareLicense?> GetByLicenseKeyAsync(string licenseKey)
    {
        return await _context.SoftwareLicenses
            .FirstOrDefaultAsync(x => x.LicenseKey == licenseKey);
    }

    public async Task<IEnumerable<SoftwareLicense>> GetAllAsync(int skip, int take)
    {
        return await  _context.SoftwareLicenses
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IQueryable<SoftwareLicense>> GetAlmostExipireds()
    {
        return _context.SoftwareLicenses
            .Where(x => x.ExpirationDate <= DateTime.UtcNow.AddDays(30));
    }
}