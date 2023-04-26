namespace server_dotnet_fitnessapp.Models;

public class UserWorkout
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid WorkoutId { get; set; }
    public Workout? Workout { get; set; }
    
}