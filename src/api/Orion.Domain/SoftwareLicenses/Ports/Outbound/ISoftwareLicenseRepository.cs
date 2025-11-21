using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Outbound;

public interface ISoftwareLicenseRepository
{
    Task CreateAsync(SoftwareLicense softwareLicense);
    Task UpdateAsync(SoftwareLicense softwareLicense);
    Task DeleteAsync(SoftwareLicense softwareLicense);
    Task<SoftwareLicense?> GetByIdAsync(Guid id);
    Task<SoftwareLicense?> GetByLicenseKeyAsync(string licenseKey);
    Task<IEnumerable<SoftwareLicense>> GetAllAsync(int skip, int take);
    Task<IEnumerable<SoftwareLicense>> GetAlmostExipireds();
}