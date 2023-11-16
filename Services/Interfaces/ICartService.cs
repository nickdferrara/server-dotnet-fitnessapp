using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Services.Interfaces;

public interface ICartService : IBaseService<Cart>
{
    Cart? GetByUserId(Guid userId);
}