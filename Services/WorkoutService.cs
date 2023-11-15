using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class WorkoutService : BaseService<Workout>, IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    
    const int DaysInFuture = 7;
    const int WorkoutsToTake = 3;
    
    public WorkoutService(
        IWorkoutRepository workoutRepository) 
        : base(workoutRepository)
    {
        _workoutRepository = _workoutRepository;
    }
    
    public Workout? FindById(Guid workoutId)
    {
        return GetById(workoutId);
    }

    public IEnumerable<Workout> GetUpcoming(Guid locationId)
    {
        DateTime today = DateTime.Today;
        DateTime futureWorkoutDate = DateTime.Today.AddDays(DaysInFuture);

        return Get()
            .Where(x => x.Location.LocationId == locationId)
            .Where(x => x.StartDateTime >= today)
            .Where(x => x.StartDateTime <= futureWorkoutDate);

    }
    
    public IEnumerable<Workout> GetByUserId (Guid userId)
    {
        DateTime today = DateTime.Today;
        DateTime futureWorkoutDate = DateTime.Today.AddDays(DaysInFuture);

        return Get()
            .Where(x => x.StartDateTime >= today)
            .Where(x => x.StartDateTime <= futureWorkoutDate)
            .Where(x => x.UserWorkouts != null && x.UserWorkouts.Any(y => y.UserId == userId))
            .Take(WorkoutsToTake);
    }
}