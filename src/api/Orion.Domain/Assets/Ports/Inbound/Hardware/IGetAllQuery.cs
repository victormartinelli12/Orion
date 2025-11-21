using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Hardware;

public interface IGetAllQuery
{
    Task<IEnumerable<Asset>> ExecuteAsync(int skip, int take);
}