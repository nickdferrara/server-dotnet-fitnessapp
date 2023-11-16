using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    
    public CartController(
        ICartService cartService
    )
    {
        _cartService = cartService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/carts")]
    [ProducesResponseType(201, Type = typeof(Cart))]
    public IActionResult Insert([FromBody] Cart cart)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_cartService.Insert(cart));
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/carts/{userId}")]
    [ProducesResponseType(200, Type = typeof(Cart))]
    public IActionResult GetByUserId([FromQuery] Guid userId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_cartService.GetByUserId(userId));
    }

}