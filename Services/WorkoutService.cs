using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class WorkoutService : BaseService<Workout>, IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    
    public WorkoutService(
        IWorkoutRepository workoutRepository) 
        : base(workoutRepository)
    {
        _workoutRepository = _workoutRepository;
    }
    
}