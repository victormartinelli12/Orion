namespace Orion.Domain.Abstraction.Responses;

public class Result
{
    public bool IsSuccess { get; }
    public Error Error { get; }
    public bool IsFailure => !IsSuccess;
    
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException("A result can not contain an error.");
        
        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException("A failure can not contain a null error.");
        
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; }
    
    private Result(T? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, Error.None);
    public new static Result<T> Failure(Error error) => new Result<T>(default(T), false, error);
    
    public static implicit operator Result<T>(T value) => Success(value);
}