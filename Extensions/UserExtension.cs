using server_dotnet_fitnessapp.Dtos;
using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Extensions;

public static class UserExtension
{
    public static User ToModel(this UserRequestDto userRequestDto) => new()
    {
        Email = userRequestDto.Email,
        Password = userRequestDto.Password
    };
    
    public static UserResponseDto ToDto(this User user) => new()
    {
        Email = user.Email,
    };
}