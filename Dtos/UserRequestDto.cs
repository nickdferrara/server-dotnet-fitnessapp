namespace server_dotnet_fitnessapp.Dtos;

public class UserRequestDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}