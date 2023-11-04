using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_dotnet_fitnessapp.Models;

public class Waitlist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid WaitlistId { get; set; }
    public Workout Workout { get; set; } = null;
    public DateTime SignedUpTime { get; set; }
}