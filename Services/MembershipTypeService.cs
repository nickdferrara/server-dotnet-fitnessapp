using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class MembershipTypeService : BaseService<MembershipType>, IMembershipTypeService
{
    public MembershipTypeService(
        IMembershipTypeRepository membershipTypeRepository
        ) : base(membershipTypeRepository)
    {
    }
}