using Orion.Domain.Employees.Entities;

namespace Orion.Domain.Employees.Ports.Outbound;

public interface IEmployeeRepository
{
    Task CreateAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task<Employee?> GetByIdAsync(Guid id);
    Task<Employee?> GetByEmailAsync(string email);
    Task DeleteAsync(Employee employee);
    Task<IEnumerable<Employee>> GetAllAsync(int skip, int take);
}