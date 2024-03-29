using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_dotnet_fitnessapp.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Person? Person { get; set; } 
    public ICollection<UserWorkout>? UserWorkouts { get; set; }
    
}