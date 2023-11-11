using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class WorkoutController : Controller
{
    private readonly IWorkoutService _workoutService;

    public WorkoutController(
        IWorkoutService workoutService
        )
    {
        _workoutService = workoutService;
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/workouts/{day}")]
    [ProducesResponseType(200, Type = typeof(User))]
    public IActionResult GetByDate([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_workoutService.Get);
    }
    
    
    
}