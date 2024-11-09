using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Services;

public class AuthService : IAuthService
{
  private readonly IAuthRepository _authRepository;
  private readonly IUserRepository _userRepository;
  public AuthService(IAuthRepository authRepository, IUserRepository userRepository)
  {
    _authRepository = authRepository;
    _userRepository = userRepository;
  }

  public async Task<User> Register(RegisterRequestDto registerDto)
  {
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
    if (await _userRepository.ExistsEmail(registerDto.Email!))
    {
      throw new Exception("Email already exists");
    }
    User user = new User(registerDto.Username, registerDto.Email, passwordHash);
    return await _authRepository.Register(user);
  }
}