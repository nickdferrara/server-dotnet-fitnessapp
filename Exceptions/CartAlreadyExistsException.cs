namespace server_dotnet_fitnessapp.Exceptions;

public class CartAlreadyExistsException : Exception
{
    public CartAlreadyExistsException()
    {
    }

    public CartAlreadyExistsException(string message)
        : base(message)
    {
    }

    public CartAlreadyExistsException(string message, Exception inner)
        : base(message, inner)
    {
    }  
    
}