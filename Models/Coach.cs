using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_dotnet_fitnessapp.Models;

public class Coach
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CoachId { get; set; }
    public bool IsActive { get; set; }
    public User User { get; set; } = null!;
    public Person Person { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public string? profilePicture { get; set; }
}