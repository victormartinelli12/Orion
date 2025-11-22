using Microsoft.EntityFrameworkCore;
using Orion.Domain.Employees.Entities;
using Orion.Domain.SoftwareLicenses.Entities;
using Orion.Domain.SoftwareLicenses.Ports.Outbound;
using Orion.Infrastructure.Data.Context;

namespace Orion.Infrastructure.Repositories.SoftwaresLicenses;

public class SoftwareAllocationRepository : ISoftwareAllocationRepository
{
    private readonly AppDbContext _context;

    public SoftwareAllocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(SoftwareAllocation softwareAllocation)
    {
        await _context.SoftwareAllocations.AddAsync(softwareAllocation);
    }

    public async Task<SoftwareAllocation?> GetByIdAsync(Guid id)
    {
        return await _context.SoftwareAllocations.FindAsync(id);
    }

    public async Task UpdateAsync(SoftwareAllocation softwareAllocation)
    {
        _context.SoftwareAllocations.Update(softwareAllocation);
    }

    public async Task<IEnumerable<SoftwareAllocation>> GetAllAsync(int skip, int take)
    {
        return await  _context.SoftwareAllocations
            .Include(x => x.Employee)
            .Include(x => x.SoftwareLicense)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<IEnumerable<SoftwareAllocation>> GetByEmployeeIdAsync(Guid employeeId)
    {
        return await _context.SoftwareAllocations
            .Where(x => x.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid employeeId)
    {
        return await _context.AssetAllocations
            .Include(x => x.Employee)
            .Select(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == employeeId);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByLicenseKeyAsync(string licenseKey)
    {
        return await _context.SoftwareAllocations
            .Include(x => x.Employee)
            .Include(x => x.SoftwareLicense)
            .Where(x => x.SoftwareLicense.LicenseKey == licenseKey)
            .Select(x => x.Employee)
            .ToListAsync();
    }
}