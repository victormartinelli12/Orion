using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Employees.Ports.Inbound;

public interface ICreateEmployeeCommand
{
    Task ExecuteAsync(Employee employee);
}