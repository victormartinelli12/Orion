using Orion.Domain.Employees.Entities;
using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Outbound;

public interface ISoftwareAllocationRepository
{
    Task CreateAsync(SoftwareAllocation softwareAllocation);
    Task<SoftwareAllocation?> GetByIdAsync(Guid id);
    Task UpdateAsync(SoftwareAllocation softwareAllocation);
    Task<IEnumerable<SoftwareAllocation>> GetAllAsync(int skip, int take);
    Task<IEnumerable<SoftwareAllocation>> GetByEmployeeIdAsync(Guid employeeId);
    Task<Employee?> GetEmployeeByIdAsync(Guid employeeId);
    Task<IEnumerable<Employee>> GetEmployeesByLicenseKeyAsync(string licenseKey);
}