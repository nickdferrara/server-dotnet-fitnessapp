using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class MembershipService : BaseService<Membership>, IMembershipService
{
    public MembershipService(IMembershipRepository membershipRepository) 
        : base(membershipRepository)
    {
    }
}