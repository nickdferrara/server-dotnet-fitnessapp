using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class AddressService : BaseService<Address>, IAddressService
{
    public AddressService(IAddressRepository addressRepository) 
        : base(addressRepository)
    {
    }
}