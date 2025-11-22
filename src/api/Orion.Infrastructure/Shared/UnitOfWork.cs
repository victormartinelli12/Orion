using Microsoft.EntityFrameworkCore.Storage;
using Orion.Domain.Abstraction.Persistence;
using Orion.Domain.Assets.Ports.Outbound;
using Orion.Domain.Employees.Ports.Outbound;
using Orion.Domain.SoftwareLicenses.Ports.Outbound;
using Orion.Infrastructure.Data.Context;
using Orion.Infrastructure.Repositories.Assets;
using Orion.Infrastructure.Repositories.Employees;
using Orion.Infrastructure.Repositories.SoftwaresLicenses;

namespace Orion.Infrastructure.Shared;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;
    
    private IAssetRepository? _assetRepository;
    private IAssetAllocationRepository? _assetAllocationRepository;
    private IAssetHistoryRepository? _assetHistoryRepository;
    private ISoftwareAllocationRepository? _softwareAllocationRepository;
    private ISoftwareLicenseRepository? _softwareLicenseRepository;
    private IEmployeeRepository? _employeeRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public IEmployeeRepository EmployeeRepository =>
        _employeeRepository ??= new EmployeeRepository(_context);
    
    public IAssetRepository AssetRepository =>
        _assetRepository ??= new AssetRepository(_context);
    
    public IAssetAllocationRepository AssetAllocationRepository =>
        _assetAllocationRepository ??= new AssetAllocationRepository(_context);
    
    public IAssetHistoryRepository AssetHistoryRepository =>
        _assetHistoryRepository ??= new AssetHistoryRepository(_context);

    public ISoftwareLicenseRepository SoftwareLicenseRepository =>
        _softwareLicenseRepository ??= new SoftwareLicenseRepository(_context);
    
    public ISoftwareAllocationRepository SoftwareAllocationRepository =>
        _softwareAllocationRepository ??= new SoftwareAllocationRepository(_context);
    
    public void Dispose()
    {
        _context.Dispose();
        _transaction?.Dispose();
    }
    
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}