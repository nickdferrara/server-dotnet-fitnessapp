using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Extensions;

public static class WorkoutExtension
{
    public static bool IsWithinTwentyFourHours(this Workout workout)
    {
        return workout.StartDateTime < DateTime.Now.AddDays(1);
    } 
    
    public static bool IsFull(this Workout workout)
    {
        return workout.Capacity <= workout.Attendees?.Count;
    }
    
    public static bool IsUserAlreadyAttending(this Workout workout, User user)
    {
        return workout.Attendees?.Any(x => x.UserId == user.UserId) ?? false;        
    }
    
    public static bool IsWithinAnHour(this Workout workout)
    {
        return workout.StartDateTime < DateTime.Now.AddHours(1);
    }
    
    //Generate an extension that checks if a users is already signed up for another workout at the same time
    
}
    
