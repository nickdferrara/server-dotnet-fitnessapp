using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Exceptions;

public static class UserWorkoutExtension
{
    public static UserWorkout Create(this UserWorkout userWorkout, User user, Workout workout)
    {
        userWorkout.UserId = user.UserId;
        userWorkout.User = user;
        userWorkout.WorkoutId = workout.WorkoutId;
        userWorkout.Workout = workout;
        return userWorkout;
    }

}