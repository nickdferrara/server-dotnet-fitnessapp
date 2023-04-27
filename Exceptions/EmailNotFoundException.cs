namespace server_dotnet_fitnessapp.Exceptions;

public class EmailNotFoundException : Exception
{
    public EmailNotFoundException()
    {
    }

    public EmailNotFoundException(string message)
        : base(message)
    {
    }

    public EmailNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }    
}