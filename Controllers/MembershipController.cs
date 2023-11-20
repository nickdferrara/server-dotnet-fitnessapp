using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

public class MembershipController : Controller
{
    private readonly IMembershipService _membershipService;

    public MembershipController(
        IMembershipService membershipService
        )
    {
        _membershipService = membershipService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/memberships")]
    [ProducesResponseType(201, Type = typeof(Membership))]
    public IActionResult Insert([FromBody] Membership membership)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_membershipService.Insert(membership));
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/memberships")]
    [ProducesResponseType(200, Type = typeof(Membership))]
    public IActionResult Update([FromBody] Membership membership)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_membershipService.Update(membership));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/memberships/{id}")]
    [ProducesResponseType(200, Type = typeof(Membership))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_membershipService.Get()
            .Where(x => x.MembershipId == id));
    }
}