using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Licenses;

public interface ICreateSoftwareCommand
{
    Task ExecuteAsync(SoftwareLicense software);
}