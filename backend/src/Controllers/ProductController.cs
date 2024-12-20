using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DTO.Request;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private readonly IProductService _productService;

  public ProductController(IProductService productService)
  {
    _productService = productService;
  }

  [Authorize(Roles = "ADMIN,USER")]
  [HttpGet]
  public async Task<IActionResult> GetProducts()
  {
    try
    {
      var products = await _productService.GetProducts();
      return Ok(new
      {
        message = "Get all product successfully",
        data = products
      });
    }
    catch (Exception)
    {
      return StatusCode(500, "Internal server error");
    }
  }

  [Authorize(Roles = "ADMIN,USER")]
  [HttpGet("{id}")]
  public async Task<IActionResult> GetProductById(Guid id)
  {
    try
    {
      try
      {
        var product = await _productService.GetProductById(id);
        return Ok(product);
      }
      catch (Exception e)
      {
        return NotFound(new
        {
          message = e.Message
        });
      }
    }
    catch (Exception)
    {
      return StatusCode(500, "Internal server error");
    }
  }

  [Authorize(Roles = "ADMIN")]
  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDto productRequestDto)
  {
    try
    {
      await _productService.CreateProduct(productRequestDto);
      return StatusCode(201, new
      {
        message = "Create product successfully"
      });
    }
    catch (Exception)
    {
      return StatusCode(500, "Internal server error");
    }
  }

  [Authorize(Roles = "ADMIN")]
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductRequestDto productRequestDto)
  {
    try
    {
      try
      {
        await _productService.UpdateProduct(id, productRequestDto);
        return Ok(new
        {
          message = "Update product successfully"
        });
      }
      catch (Exception e)
      {
        return NotFound(new
        {
          message = e.Message
        });
      }
    }
    catch (Exception)
    {
      return StatusCode(500, "Internal server error");
    }
  }

  [Authorize(Roles = "ADMIN")]
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(Guid id)
  {
    try
    {
      try
      {
        await _productService.DeleteProduct(id);
        return Ok(new
        {
          message = "Delete product successfully"
        });
      }
      catch (Exception)
      {
        return NotFound(new
        {
          message = "Product not found"
        });
      }
    }
    catch (Exception)
    {
      return StatusCode(500, "Internal server error");
    }
  }
}
