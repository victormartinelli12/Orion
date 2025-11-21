using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Licenses;

public interface IGetAllSoftwaresQuery
{
    Task<IEnumerable<SoftwareLicense>> ExecuteAsync(int skip, int take);
}