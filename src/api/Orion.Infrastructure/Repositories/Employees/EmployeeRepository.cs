using Microsoft.EntityFrameworkCore;
using Orion.Domain.Employees.Entities;
using Orion.Domain.Employees.Ports.Outbound;
using Orion.Infrastructure.Data.Context;

namespace Orion.Infrastructure.Repositories.Employees;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee); 
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await _context.Employees.FindAsync(email);
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(int skip, int take)
    {
        return await _context.Employees
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }
}