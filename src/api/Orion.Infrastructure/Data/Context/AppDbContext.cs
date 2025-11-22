using Microsoft.EntityFrameworkCore;
using Orion.Domain.Assets.Entities;
using Orion.Domain.Employees.Entities;
using Orion.Domain.SoftwareLicenses.Entities;
using Orion.Infrastructure.Data.Configuration;

namespace Orion.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetAllocation> AssetAllocations { get; set; }
    public DbSet<AssetHistory> AssetHistories { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<SoftwareLicense> SoftwareLicenses { get; set; }
    public DbSet<SoftwareAllocation> SoftwareAllocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AssetAllocationDbConfiguration());
        modelBuilder.ApplyConfiguration(new AssetDbConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeDbConfiguration());
        modelBuilder.ApplyConfiguration(new AssetHistoryDbConfiguration());
        modelBuilder.ApplyConfiguration(new SoftwareLicenseDbConfiguration());
        modelBuilder.ApplyConfiguration(new SoftwareAllocationDbConfiguration());
    }
}