using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class UserService : BaseService<User>, IUserRepository
{
    public UserService(
        IUserRepository userRepository
        ) : base(userRepository)
    {        
    }    
}