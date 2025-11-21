using Orion.Domain.Assets.Enums;

namespace Orion.Domain.Assets.Ports.Inbound.Hardware;

public interface IUpdateStatusCommand
{
    Task ExecuteAsync(EAssetStatus  status);
}