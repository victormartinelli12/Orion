using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Licenses;

public interface IGetAlmostExpiredsSoftwaresQuery
{
    Task<IEnumerable<SoftwareLicense>> ExecuteAsync();
}