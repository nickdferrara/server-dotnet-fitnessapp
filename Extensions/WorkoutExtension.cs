using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Extensions;

public static class WorkoutExtension
{
    public static bool IsWithinTwentyFourHours(this Workout workout)
    {
        return workout.StartDateTime < DateTime.Now.AddDays(1);
    }    
}
    
