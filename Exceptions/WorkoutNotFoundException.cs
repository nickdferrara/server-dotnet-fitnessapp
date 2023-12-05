namespace server_dotnet_fitnessapp.Exceptions;

public class WorkoutNotFoundException : Exception
{
    public WorkoutNotFoundException()
    {
    }

    public WorkoutNotFoundException(string message)
        : base(message)
    {
    }

    public WorkoutNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }    
}