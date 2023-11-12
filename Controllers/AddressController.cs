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
}