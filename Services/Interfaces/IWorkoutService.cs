using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Services.Interfaces;

public interface IWorkoutService : IBaseService<Workout>
{
    Workout? FindById(Guid workoutId);

    IEnumerable<Workout> GetUpcoming(Guid locationId);

    IEnumerable<Workout> GetByUserId(Guid userId);

    Workout Cancel(Guid workoutId, Guid userId);
}