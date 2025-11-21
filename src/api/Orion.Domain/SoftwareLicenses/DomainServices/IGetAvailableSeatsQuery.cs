namespace Orion.Domain.SoftwareLicenses.DomainServices;

public interface IGetAvailableSeatsQuery
{
    Task<int> ExecuteAsync(Guid softwareId);
}