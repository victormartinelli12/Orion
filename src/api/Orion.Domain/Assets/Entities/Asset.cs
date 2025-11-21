using Orion.Domain.Abstraction;
using Orion.Domain.Assets.Enums;
using Orion.Domain.Persons.ValueObjects;

namespace Orion.Domain.Assets.Entities;

public class Asset : Entity
{
    public Name Model { get; init; } = null!;
    public string SerialNumber { get; init; } = string.Empty;
    public EAssetType Type { get; init; }
    public DateTime PurchaseDate { get; init; }
    public DateTime WarrentyEndDate { get; init; }
    public EAssetStatus Status { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    private Asset() {}

    public void UpdateStatus(EAssetStatus status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }

    public void TakeAsset()
    {
        Status = EAssetStatus.Allocated;
        UpdatedAt = DateTime.UtcNow;
    }

    public void PutInMainitence() 
    {
        Status = EAssetStatus.UnderMaintenance;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Retired() 
    {
        Status = EAssetStatus.Retired;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Asset> Create(string model, string serialNumber,
        EAssetType type, DateTime purchaseDate, DateTime warrentyEndDate, EAssetStatus status = EAssetStatus.InStock)
    {
        if (warrentyEndDate.Date < purchaseDate.Date)
            return Result<Asset>.Failure(
                new Error("Invalid.Warrenty", "Warrenty date cannot be earlier than purchase"));
        
        if (warrentyEndDate.Date == purchaseDate.Date)
            return Result<Asset>.Failure(new Error("Invalid.Warrenty", "Warrenty cannot be equal purchase"));

        return new Asset
        {
            Id = Guid.NewGuid(),
            Model = Name.Create(model).Value!,
            SerialNumber = serialNumber,
            Type =  type,
            PurchaseDate = purchaseDate,
            WarrentyEndDate = warrentyEndDate,
            Status =  status,
            CreatedAt =  DateTime.UtcNow
        };
    }
}