using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Employees.Ports.Inbound;

public interface IUpdateRoleCommand
{
    Task ExecuteAsync(Employee employee);
}