using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class CoachController : Controller
{
    private readonly ICoachService _coachService;

    public CoachController(ICoachService coachService)
    {
        _coachService = coachService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/coaches")]
    [ProducesResponseType(201, Type = typeof(Coach))]
    public IActionResult Insert([FromBody] Coach coach)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_coachService.Insert(coach));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/coaches/{id}")]
    [ProducesResponseType(200, Type = typeof(Coach))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_coachService.GetById(id));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/coaches")]
    [ProducesResponseType(200, Type = typeof(Coach))]
    public IActionResult Update([FromBody] Coach coach)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_coachService.Update(coach));
    }

}