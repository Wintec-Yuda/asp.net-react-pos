using PointOfSale.DTO.Request;

namespace PointOfSale.Services.Interfaces;

public interface IAuthService
{
  Task Register(RegisterRequestDto registerRequestDto);
  Task<string> Login(LoginRequestDto loginRequestDto);
}