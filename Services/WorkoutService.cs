using Azure.Identity;
using server_dotnet_fitnessapp.Exceptions;
using server_dotnet_fitnessapp.Extensions;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class WorkoutService : BaseService<Workout>, IWorkoutService
{
    private readonly IUserService _userService;
    
    const int DaysInFuture = 7;
    const int WorkoutsToTake = 3;
    
    public WorkoutService(
        IWorkoutRepository workoutRepository) 
        : base(workoutRepository)
    {
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

        //TODO: Filter by user id
        return Get()
            .Where(x => x.StartDateTime >= today)
            .Where(x => x.StartDateTime <= futureWorkoutDate)
            .Take(WorkoutsToTake);
    }
    
    public Workout Cancel(Guid workoutId, Guid userId)
    {
        var workout = FindById(workoutId);

        if (workout is null)
            throw new WorkoutNotFoundException("Workout not found.");
        
        if (workout.IsWithinTwentyFourHours())
            throw new WorkoutWithinTwentyFourHourException(
                "Workout cannot be cancelled within 24 hours of start time.");
        
        
        //TODO: Remove user from workout
        Update(workout);
        
        return workout;
    }
    
}