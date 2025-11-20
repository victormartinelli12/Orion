namespace Orion.Domain.Abstraction;

public class PagedResult<T> where T : Entity
{
    public IEnumerable<T>? Data { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}