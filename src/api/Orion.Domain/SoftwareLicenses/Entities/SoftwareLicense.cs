using Orion.Domain.Abstraction;
using Orion.Domain.Persons.ValueObjects;

namespace Orion.Domain.SoftwareLicenses.Entities;

public class SoftwareLicense : Entity
{
    public Name Name { get; init; } = null!;
    public string LicenseKey { get; init; } = string.Empty;
    public DateTime PurchaseDate { get; init; }
    public DateTime ExpirationDate { get; init; }
    public int Seats { get; init; }
    
    public ICollection<SoftwareAllocation> Allocations { get; private set; } =  new List<SoftwareAllocation>();
    
    private SoftwareLicense() {}

    public static Result<SoftwareLicense> Create(string name, string licenseKey,
        DateTime purchaseDate, DateTime expirationDate, int seats)
    {
        if (string.IsNullOrEmpty(licenseKey))
            return Result<SoftwareLicense>.Failure(new Error("Empty.License", "License key cannot be null."));

        if (purchaseDate.Date > expirationDate.Date)
            return Result<SoftwareLicense>.Failure(new Error("Invalid.PurhcaseDate",
                "Purchase date cannot be earlier than expiration"));

        if (purchaseDate.Date == expirationDate.Date)
            return Result<SoftwareLicense>.Failure(new Error("Invalid.PurchaseDate",
                "Purchase date cannot be equal then expiration"));

        if (seats <= 0)
            return Result<SoftwareLicense>.Failure(new Error("Invalid.SeatsValue", "Seats value cannot be less than one."));

        return new SoftwareLicense
        {
            Id = Guid.NewGuid(),
            Name = Name.Create(name).Value!,
            LicenseKey = licenseKey,
            PurchaseDate = purchaseDate,
            ExpirationDate = expirationDate,
            Seats = seats,
            CreatedAt = DateTime.UtcNow
        };
    }
}