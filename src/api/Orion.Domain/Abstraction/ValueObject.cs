namespace Orion.Domain.Abstraction;

public abstract class ValueObject
{
    public override bool Equals(object? obj)
    {
        return obj is ValueObject other  && Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}