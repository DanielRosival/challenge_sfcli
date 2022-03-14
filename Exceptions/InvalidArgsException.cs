namespace sfcli.Exceptions;

public class InvalidArgsException : Exception
{
    public InvalidArgsException()
    {
    }

    public InvalidArgsException(string message)
        : base(message)
    {
    }

    public InvalidArgsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}