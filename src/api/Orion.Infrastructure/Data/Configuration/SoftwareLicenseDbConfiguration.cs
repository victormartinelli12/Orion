using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orion.Domain.SoftwareLicenses.Entities;

namespace Orion.Infrastructure.Data.Configuration;

public class SoftwareLicenseDbConfiguration : IEntityTypeConfiguration<SoftwareLicense>
{
    public void Configure(EntityTypeBuilder<SoftwareLicense> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Seats)
            .IsRequired();

        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        });
        
        builder.HasMany(x => x.Allocations)
            .WithOne(x => x.SoftwareLicense)
            .HasForeignKey(x => x.SoftwareLicenseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.LicenseKey)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.PurchaseDate)
            .IsRequired()
            .HasColumnType("date");
        
        builder.Property(x => x.ExpirationDate)
            .IsRequired()
            .HasColumnType("date");
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}