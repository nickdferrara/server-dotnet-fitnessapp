using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Controllers;

[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService
        )
    {
        _productService = productService;
    }
    
    [AllowAnonymous]
    [HttpPost("/api/v1/products")]
    [ProducesResponseType(201, Type = typeof(Product))]
    public IActionResult Insert([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_productService.Insert(product));
    }
    
    //TODO: Introduce paging for infinite scroll
    [AllowAnonymous]
    [HttpGet("/api/v1/products")]
    [ProducesResponseType(200, Type = typeof(Product))]
    public IActionResult Get([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_productService.Get());
    }
    
    [AllowAnonymous]
    [HttpGet("/api/v1/products/{id}")]
    [ProducesResponseType(200, Type = typeof(Product))]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_productService.GetById(id));
    }
    
    [AllowAnonymous]
    [HttpPut("/api/v1/products/{id}")]
    [ProducesResponseType(200, Type = typeof(Product))]
    public IActionResult Update([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_productService.Update(product));
    }
    
    [AllowAnonymous]
    [HttpDelete("/api/v1/products/{id}")]
    [ProducesResponseType(200, Type = typeof(Product))]
    public IActionResult Delete([FromQuery] Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _productService.DeleteById(id);
        
        return Ok();
    }    
}