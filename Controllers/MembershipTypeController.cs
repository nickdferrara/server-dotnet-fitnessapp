using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class MembershipTypeController : Controller
{
    private readonly IMembershipTypeService _membershipTypeService;

    public MembershipTypeController(
        IMembershipTypeService membershipTypeService
        )
    {
        _membershipTypeService = membershipTypeService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/membershiptypes")]
    [ProducesResponseType(201, Type = typeof(MembershipType))]
    public IActionResult RegisterUser([FromBody] MembershipType membershipType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_membershipTypeService.Insert(membershipType));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/membershiptypes/{id}")]
    [ProducesResponseType(200, Type = typeof(MembershipType))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_membershipTypeService.GetById(id));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/membershiptypes")]
    [ProducesResponseType(200, Type = typeof(MembershipType))]
    public IActionResult Update([FromBody] MembershipType membershipType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_membershipTypeService.Update(membershipType));
    }
    
    [AllowAnonymous]
    [HttpDelete("/api/v1/membershiptypes/{id}")]
    [ProducesResponseType(200, Type = typeof(MembershipType))]
    public IActionResult Update([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _membershipTypeService.DeleteById(id);

        return Ok();
    }    
}