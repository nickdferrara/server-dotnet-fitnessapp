using server_dotnet_fitnessapp.Context;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;

namespace server_dotnet_fitnessapp.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}