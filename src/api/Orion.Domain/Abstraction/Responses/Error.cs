namespace Orion.Domain.Abstraction.Responses;

public class Error
{
    public string Code { get; protected set; }
    public string Message { get; protected set; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    
    public static Error None => new Error(string.Empty, string.Empty);
    public static Error NullValue => new Error("Error.NullValue", "The specified value is null.");
}