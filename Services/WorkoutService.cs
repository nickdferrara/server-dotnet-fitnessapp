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
        
        var user = _userService.FindById(userId);
        
        if (user is null) 
            throw new UserNotFoundException("User not found.");
        
        if (workout.IsWithinTwentyFourHours())
            throw new WorkoutWithinTwentyFourHourException(
                "Workout cannot be cancelled within 24 hours of start time.");
        
        workout.Attendees?.Remove(new UserWorkout().Create(user, workout))
            .Also(x => Update(workout));
        
        return workout;
    }
    
    public Workout SignUp(Guid workoutId, Guid userId)
    {
        var workout = FindById(workoutId);

        if (workout is null)
            throw new WorkoutNotFoundException("Workout not found.");
        
        var user = _userService.FindById(userId);
        
        if (user is null) 
            throw new UserNotFoundException("User not found.");
        
        if (workout.IsWithinAnHour())
            throw new WorkoutSignUpPeriodClosedException("Workout is closed for sign ups.");
        
        if (workout.IsFull())
            throw new WorkoutFullException("Workout is full, would you like to be added to the waitlist?");
        
        if (workout.IsUserAlreadyAttending(user))
            throw new UserAlreadyRegisteredException("You are already registered for this workout.");
        
        
        if (IsUserAlreadySignedUpForWorkoutAtSameTime(user, workout))
            throw new UserAlreadyRegisteredException("User is already registered for a workout at this time.");

        workout.Attendees?.Add(new UserWorkout().Create(user, workout));
        Update(workout);
        
        return workout;
    }

    private bool IsUserAlreadySignedUpForWorkoutAtSameTime(User user, Workout workout)
    {
        return GetByUserId(user.UserId).Any(x => x.StartDateTime == workout.StartDateTime);
    }
}