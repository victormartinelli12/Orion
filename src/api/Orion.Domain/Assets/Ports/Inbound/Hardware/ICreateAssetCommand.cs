using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Hardware;

public interface ICreateAssetCommand
{
    Task ExecuteAsync(Asset asset);
}