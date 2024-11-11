using PointOfSale.DTO;
using PointOfSale.Models;

namespace PointOfSale.Services.Interfaces;

public interface IAuthService
{
  Task Register(RegisterRequestDto registerDto);
  Task<string> Login(LoginRequestDto loginDto);
}