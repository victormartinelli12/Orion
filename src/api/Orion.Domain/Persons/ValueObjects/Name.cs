using Orion.Domain.Abstraction;

namespace Orion.Domain.Persons.ValueObjects;

public sealed class Name : ValueObject
{
    public string Value { get; }
    
    private const int MaxLength = 32;
    private const int MinLength = 2;

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Name>.Failure(new Error("Empty.Name", "Names cannot be null"));

        if (value.Length >= MaxLength || value.Length <= MinLength)
            return Result<Name>.Failure(new Error("Invalid.Name", "Name must have length between 2-32 characters."));

        return new Name(value);
    }
}