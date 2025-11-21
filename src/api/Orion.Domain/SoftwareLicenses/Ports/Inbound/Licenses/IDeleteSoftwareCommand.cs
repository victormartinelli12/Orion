using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Licenses;

public interface IDeleteSoftwareCommand
{
    Task ExecuteAsync(SoftwareLicense software);
}