using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Licenses;

public interface IGetByLicenseKeyQuery
{
    Task<SoftwareLicense?> ExecuteAsync(string licenseKey);
}