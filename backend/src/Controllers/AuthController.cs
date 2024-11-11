using Microsoft.AspNetCore.Mvc;
using PointOfSale.DTO;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService) => _authService = authService;

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody]RegisterRequestDto registerDto)
  {
    try
    {
      await _authService.Register(registerDto);
      return Ok(new
      {
        message = "User registered successfully"
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

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody]LoginRequestDto loginDto)
  {
    try
    {
      string token = await _authService.Login(loginDto);
      return Ok(new {
        message = "User logged in successfully",
        token
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
}