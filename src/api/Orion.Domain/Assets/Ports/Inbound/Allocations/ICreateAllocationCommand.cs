using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Allocations;

public interface ICreateAllocationCommand
{
    Task ExecuteAsync(AssetAllocation allocation);
}