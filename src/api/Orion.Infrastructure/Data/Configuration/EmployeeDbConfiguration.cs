using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orion.Domain.Employees.Entities;

namespace Orion.Infrastructure.Data.Configuration;

public class EmployeeDbConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();
        
        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();
        });
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Role)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnType("timestamptz");
    }
}