using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;

namespace PointOfSale.Services.Interfaces;

public interface IAuthService
{
  Task<User> Register(RegisterRequestDto registerDto);
}