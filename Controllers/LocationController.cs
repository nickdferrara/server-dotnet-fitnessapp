using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;

    public LocationController(
        ILocationService locationService
        )
    {
        _locationService = locationService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/locations")]
    [ProducesResponseType(201, Type = typeof(Location))]
    public IActionResult Insert([FromBody] Location location)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_locationService.Insert(location));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/locations")]
    [ProducesResponseType(200, Type = typeof(Location))]
    public IActionResult Update([FromBody] Location location)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_locationService.Update(location));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/locations")]
    [ProducesResponseType(200, Type = typeof(Location))]
    public IActionResult Get([FromBody] Location location)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_locationService.Get());
    }  
    
    [AllowAnonymous]
    [HttpGet("/api/v1/locations/{id}")]
    [ProducesResponseType(200, Type = typeof(Location))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_locationService.Get()
            .Where(x => x.LocationId == id));
    }      
}