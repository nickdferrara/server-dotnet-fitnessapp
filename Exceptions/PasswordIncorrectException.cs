namespace server_dotnet_fitnessapp.Exceptions;

public class PasswordIncorrectException : Exception
{
    public PasswordIncorrectException()
    {
    }

    public PasswordIncorrectException(string message)
        : base(message)
    {
    }

    public PasswordIncorrectException(string message, Exception inner)
        : base(message, inner)
    {
    }        
}