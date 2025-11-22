namespace Orion.Domain.Shared.Ports.Inbound;

public interface IEncryptData
{
    Task ExecuteAsync(string data);
}