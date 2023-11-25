using server_dotnet_fitnessapp.Context;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;

namespace server_dotnet_fitnessapp.Repositories;

public class UserWorkoutRepository : BaseRepository<UserWorkout>, IUserWorkoutRepository
{
    public UserWorkoutRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}