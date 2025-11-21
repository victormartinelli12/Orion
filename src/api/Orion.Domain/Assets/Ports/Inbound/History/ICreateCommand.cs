using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.History;

public interface ICreateCommand
{
    Task ExecuteAsync(AssetHistory history);
}