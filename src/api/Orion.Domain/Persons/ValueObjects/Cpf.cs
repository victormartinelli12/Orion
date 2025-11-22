using Orion.Domain.Abstraction;
using Orion.Domain.Abstraction.Entities;
using Orion.Domain.Abstraction.Responses;

namespace Orion.Domain.Persons.ValueObjects;

public sealed class Cpf : ValueObject
{
    public string Value { get; }

    private const int Length = 11;

    private Cpf(string value)
    {
        Value = value;
    }

    public static Result<Cpf> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Cpf>.Failure(new Error("Empty.Cpf", "CPF value can not be null"));

        if (value.Length != Length)
            return Result<Cpf>.Failure(new Error("Invalid.Cpf", "CPF must have 11 characters"));
        
        if (value.Distinct().Count() == 1)
            return Result<Cpf>.Failure(new Error("Invalid.Cpf", "CPF can not have all equal digits"));
        
        if (!IsValidCpf(value))
            return Result<Cpf>.Failure(new Error("Invalid.Cpf", "Invalid CPF"));
        
        return new Cpf(value);
    }

    private static bool IsValidCpf(string cpf)
    {
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += (cpf[i] - '0') * (i + 1);
        }

        int remainder = sum % 11;
        int firstDigit = remainder < 2 ? 0 : 11 - remainder;
        
        if (firstDigit != (cpf[9] - '0'))
            return false;
        
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += (cpf[i] - '0') * (11 - i);
        
        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        return digit2 == (cpf[10] - '0');
    }
}