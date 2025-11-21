using Orion.Domain.Assets.Entities;

namespace Orion.Domain.Assets.Ports.Inbound.Hardware;

public interface IGetBySerialNumberQuery
{
    Task<Asset?> ExecuteAsync(string serialNumber);
}