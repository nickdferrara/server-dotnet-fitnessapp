using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(
        IPersonService personService
        )
    {
        _personService = personService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/people")]
    [ProducesResponseType(201, Type = typeof(Person))]
    public IActionResult Insert([FromBody] Person person)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_personService.Insert(person));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/people/{id}")]
    [ProducesResponseType(200, Type = typeof(Person))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_personService.GetById(id));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/people")]
    [ProducesResponseType(200, Type = typeof(Person))]
    public IActionResult Update([FromBody] Person person)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_personService.Update(person));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/people")]
    [ProducesResponseType(200, Type = typeof(Person))]
    public IActionResult Delete([FromBody] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _personService.DeleteById(id);
        
        return Ok();
    }
}