using Orion.Domain.Abstraction;
using Orion.Domain.Persons.ValueObjects;

namespace Orion.Domain.Persons.Entities;

public class Person : Entity
{
    public Name FirstName { get; private set; } = null!;
    public Name LastName { get; private set; } = null!;
    public int Age { get; private set; }
    public Cpf Cpf { get; init; } = null!;
    public DateTime? UpdatedAt { get; private set; }

    private Person() {}

    public void ChangeFirsName(string name)
    {
        FirstName = Name.Create(name).Value!;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeLastName(string name)
    {
        LastName = Name.Create(name).Value!;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Person> Create(string firstName, string lastName, int age, string cpf)
    {
        if (age < 18 || age > 75)
            return Result<Person>.Failure(new Error("Invalid.Age", "Age must be between 18-75 years"));

        return new Person
        {
            Id = Guid.NewGuid(),
            FirstName = Name.Create(firstName).Value!,
            LastName = Name.Create(lastName).Value!,
            Age = age,
            Cpf = Cpf.Create(cpf).Value!,
            CreatedAt = DateTime.UtcNow
        };
    }
}