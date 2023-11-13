using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class AddressController : Controller
{
    private readonly IAddressService _addressService;

    public AddressController(
        IAddressService addressService
        )
    {
        _addressService = addressService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/address")]
    [ProducesResponseType(201, Type = typeof(Address))]
    public IActionResult RegisterUser([FromBody] Address address)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_addressService.Insert(address));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/address/{addressId}")]
    [ProducesResponseType(200, Type = typeof(Address))]
    public IActionResult GetById([FromQuery] Guid addressId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_addressService.GetById(addressId));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/address")]
    [ProducesResponseType(200, Type = typeof(Address))]
    public IActionResult Update([FromBody] Address address)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_addressService.Update(address));
    }
    
    [AllowAnonymous]
    [HttpDelete("/api/v1/address/{addressId}")]
    [ProducesResponseType(200, Type = typeof(void))]
    public IActionResult DeleteById([FromQuery] Guid addressId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _addressService.DeleteById(addressId);
        return Ok();
    }
}