namespace Orion.Domain.SoftwareLicenses.Ports.Inbound.Allocations;

public interface IDesallocationSoftwareCommand
{
    Task  ExecuteAsync(Guid softwareId);
}