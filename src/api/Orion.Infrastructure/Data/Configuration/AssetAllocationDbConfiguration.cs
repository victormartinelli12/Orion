using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orion.Domain.Assets.Entities;

namespace Orion.Infrastructure.Data.Configuration;

public class AssetAllocationDbConfiguration : IEntityTypeConfiguration<AssetAllocation>
{
    public void Configure(EntityTypeBuilder<AssetAllocation> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.AllocationDate)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        builder.Property(x => x.DesallocationDate)
            .HasColumnType("timestamptz");

        builder.Property(x => x.AssetId)
            .IsRequired();
        builder.HasOne(x => x.Asset)
            .WithMany()
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.EmployeeId)
            .IsRequired();
        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}