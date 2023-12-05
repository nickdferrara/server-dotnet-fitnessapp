namespace server_dotnet_fitnessapp.Exceptions;

public class WorkoutWithinTwentyFourHourException : Exception
{
public WorkoutWithinTwentyFourHourException()
    {
    }

    public WorkoutWithinTwentyFourHourException(string message)
        : base(message)
    {
    }

    public WorkoutWithinTwentyFourHourException(string message, Exception inner)
        : base(message, inner)
    {
    }    
}