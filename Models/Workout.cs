using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_dotnet_fitnessapp.Models;

public class Workout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid WorkoutId { get; set; }
    public Location Location { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; } = 0;    
    public DateTime StartDateTime { get; set; }
    public int MinuteDuration { get; set; }
    public Coach Coach { get; set; } = null!;
    public IList<UserWorkout>? UserWorkouts { get; set; }
}