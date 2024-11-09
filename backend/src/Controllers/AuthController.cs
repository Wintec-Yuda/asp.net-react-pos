using Microsoft.AspNetCore.Mvc;
using PointOfSale.Repositories.Interfaces;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService) => _authService = authService;

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequestDto registerDto)
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
}