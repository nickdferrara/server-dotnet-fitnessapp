namespace server_dotnet_fitnessapp.Exceptions;

public class WorkoutSignUpPeriodClosedException : Exception
{
    public WorkoutSignUpPeriodClosedException()
    {
    }

    public WorkoutSignUpPeriodClosedException(string message)
        : base(message)
    {
    }

    public WorkoutSignUpPeriodClosedException(string message, Exception inner)
        : base(message, inner)
    {
    }      
}