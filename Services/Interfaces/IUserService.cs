using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    User Login(User user);
}