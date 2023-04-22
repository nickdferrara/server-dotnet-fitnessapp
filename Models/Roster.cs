using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_dotnet_fitnessapp.Models;

public class Roster
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid RosterId { get; set; }
    public ICollection<User> Users { get; set; } = null!;
    [ForeignKey(nameof(Workout))]
    public Guid WorkoutId { get; set; }

    public virtual Workout Workout { get; set; } = null!;
}