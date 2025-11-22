using System.Text.RegularExpressions;
using Orion.Domain.Abstraction;
using Orion.Domain.Abstraction.Entities;
using Orion.Domain.Abstraction.Responses;

namespace Orion.Domain.Employees.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }
    
    private const int  MinLength = 6;
    private const int MaxLength = 60;

    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    private Email(string value)
    {
        Value = value.ToLowerInvariant();
    }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result<Email>.Failure(new Error("Empty.Email", "Email can not be null."));
        
        if (value.Length > MaxLength || value.Length < MinLength)
            return Result<Email>.Failure(new Error("Invalid.Email", "Email length must have between 6-60 characters."));
        
        if (!IsValidEmail(value))
            return Result<Email>.Failure(new Error("Invalid.Email", "Invalid email."));

        return new Email(value);
    }

    private static bool IsValidEmail(string value)
    {
        if (!EmailRegex.IsMatch(value))
            return false;

        string[] parts = value.Split('@');

        if (parts.Length != 2)
            return false;

        if (parts[0].StartsWith('.') || parts[0].EndsWith('.') || parts[0].Contains(".."))
            return false;

        if (parts[1].StartsWith('-') || parts[1].EndsWith('-'))
            return false;

        return true;
    }
}