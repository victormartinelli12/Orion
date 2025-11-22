using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orion.Domain.Assets.Entities;

namespace Orion.Infrastructure.Data.Configuration;

public class AssetDbConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(x => x.Model, assetModel =>
        {
            assetModel.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Model");
        });

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(x => x.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.SerialNumber)
            .IsRequired();
        builder.HasIndex(x => x.SerialNumber)
            .IsUnique();

        builder.Property(x => x.PurchaseDate)
            .IsRequired()
            .HasColumnType("date");
        
        builder.Property(x => x.WarrentyEndDate)
            .HasColumnType("date");
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}