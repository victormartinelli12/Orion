namespace Orion.Domain.Shared.Ports.Inbound;

public interface IDescryptData
{
    Task<bool> ExecuteAsync(string data);
}