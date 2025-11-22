using Orion.Domain.Assets.Ports.Outbound;
using Orion.Domain.Employees.Ports.Outbound;
using Orion.Domain.SoftwareLicenses.Ports.Outbound;

namespace Orion.Domain.Abstraction.Persistence;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IAssetRepository AssetRepository { get; }
    IAssetAllocationRepository AssetAllocationRepository { get; }
    IAssetHistoryRepository AssetHistoryRepository { get; }
    ISoftwareLicenseRepository  SoftwareLicenseRepository { get; }
    ISoftwareAllocationRepository SoftwareAllocationRepository { get; }
    Task CommitAsync();
    Task RollbackAsync();
}