using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DTO.Request;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService) => _authService = authService;

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
  {
    try
    {
      await _authService.Register(registerRequestDto);
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
  public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
  {
    try
    {
      string token = await _authService.Login(loginRequestDto);
      return Ok(new
      {
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