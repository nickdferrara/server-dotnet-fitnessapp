using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(
        IUserService userService
        )
    {
        _userService = userService;
    }

    [HttpPost("/api/v1/users/registeruser")]
    [ProducesResponseType(201, Type = typeof(User))]
    public IActionResult RegisterUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_userService.Insert(user));
    }
}