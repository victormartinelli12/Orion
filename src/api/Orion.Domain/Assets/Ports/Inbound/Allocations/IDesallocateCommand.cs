using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Allocations;

public interface IDesallocateCommand
{
    Task ExecuteAsync(AssetAllocation allocation);
}