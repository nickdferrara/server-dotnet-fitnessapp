using System.ComponentModel.DataAnnotations;

namespace server_dotnet_fitnessapp.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}