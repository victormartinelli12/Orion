using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Hardware;

public interface IGetWarrentyEndingQuery
{
    Task<IEnumerable<Asset>> ExecuteAsync();
}