namespace server_dotnet_fitnessapp.Exceptions;

public class WorkoutFullException : Exception
{
    public WorkoutFullException()
    {
    }

    public WorkoutFullException(string message)
        : base(message)
    {
    }

    public WorkoutFullException(string message, Exception inner)
        : base(message, inner)
    {
    }      
}