using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Employees.Ports.Inbound;

public interface IGetAllEmployeeQuery
{
    Task<IEnumerable<Employee>> ExecuteAsync(int skip, int take);
}