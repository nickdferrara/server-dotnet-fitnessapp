namespace server_dotnet_fitnessapp.Exceptions;

public class UserAlreadyRegisteredException : Exception
{
    public UserAlreadyRegisteredException()
    {
    }

    public UserAlreadyRegisteredException(string message)
        : base(message)
    {
    }

    public UserAlreadyRegisteredException(string message, Exception inner)
        : base(message, inner)
    {
    }
}