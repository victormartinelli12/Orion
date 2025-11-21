using Orion.Domain.Abstraction;
using Orion.Domain.Employees.Enums;
using Orion.Domain.Employees.ValueObjects;
using Orion.Domain.Persons.Entities;

namespace Orion.Domain.Employees.Entities;

public class Employee : Entity
{
    public Email Email { get; init; } = null!;
    public string Password { get; private set; } = null!;
    public ERole Role { get; private set; }
    public string PhoneNumber { get; private set; } = null!;
    public DateTime? UpdatedAt { get; private set; }
    
    private Employee() {}

    public void UpdatePassword(string password)
    {
        Password = password;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateRole(ERole role)
    {
        Role = role;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Employee> Create(string email, string password, ERole role, string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return Result<Employee>.Failure(new Error("Empty.PhoneNumber", "Phone number can not be null"));
        
        if (string.IsNullOrEmpty(password))
            return Result<Employee>.Failure(new Error("Empty.Password", "Password can not be null"));
        
        if (password.Length < 8)
            return Result<Employee>.Failure(new Error("Password.Length", "Password length must have be bigger than 8 characters"));

        return new Employee
        {
            Id = Guid.NewGuid(),
            Email = Email.Create(email).Value!,
            Password = password,
            Role = role,
            PhoneNumber = phoneNumber
        };
    }
}