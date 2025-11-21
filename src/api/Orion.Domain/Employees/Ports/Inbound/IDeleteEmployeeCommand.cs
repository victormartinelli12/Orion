using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Employees.Ports.Inbound;

public interface IDeleteEmployeeCommand
{
    Task ExecuteAsync(Employee employee);
}