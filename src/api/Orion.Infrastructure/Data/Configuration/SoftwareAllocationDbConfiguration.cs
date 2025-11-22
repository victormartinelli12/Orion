using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Infrastructure.Data.Configuration;

public class SoftwareAllocationDbConfiguration : IEntityTypeConfiguration<SoftwareAllocation>
{
    public void Configure(EntityTypeBuilder<SoftwareAllocation> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.AllocationDate)
            .IsRequired()
            .HasColumnType("timestamptz");

        builder.Property(x => x.DesallocationDate)
            .HasColumnType("timestamptz");
        
        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.SoftwareLicense)
            .WithMany()
            .HasForeignKey(x => x.SoftwareLicenseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}