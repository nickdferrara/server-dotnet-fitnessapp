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
    [HttpGet("/api/v1/workouts")]
    [ProducesResponseType(200, Type = typeof(Workout))]
    public IActionResult GetUpcoming()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_workoutService.GetUpcoming());
    } 
    
    [AllowAnonymous]
    [HttpGet("/api/v1/workouts/{id}")]
    [ProducesResponseType(200, Type = typeof(Workout))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_workoutService.FindById(id));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/workouts/{userId}")]
    [ProducesResponseType(200, Type = typeof(Workout))]
    public IActionResult GetByUserId([FromQuery] Guid userId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_workoutService.GetByUserId(userId));
    } 
}