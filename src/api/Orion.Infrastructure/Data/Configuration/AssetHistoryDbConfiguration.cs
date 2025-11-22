using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orion.Domain.Assets.Entities;

namespace Orion.Infrastructure.Data.Configuration;

public class AssetHistoryDbConfiguration : IEntityTypeConfiguration<AssetHistory>
{
    public void Configure(EntityTypeBuilder<AssetHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NewStatus)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.OldStatus)
            .IsRequired()
            .HasConversion<string>();

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

        builder.Property(x => x.ChangedAt)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}