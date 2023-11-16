using server_dotnet_fitnessapp.Exceptions;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class CartService : BaseService<Cart>, ICartService
{
    public CartService(ICartRepository cartRepository) 
        : base(cartRepository)
    {
    }

    public Cart Insert(Guid id, Cart cart)
    {
        var existingCart = GetById(id);
        if (existingCart is not null)
        {
            throw new CartAlreadyExistsException("Cart already exists.");
        }

        return Insert(cart);
    }

    public Cart? GetByUserId(Guid userId)
    {
        return Get()
            .FirstOrDefault(x => x.User.UserId == userId);
    }
}