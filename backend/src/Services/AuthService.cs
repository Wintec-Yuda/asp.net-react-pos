using PointOfSale.DTO;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;
using PointOfSale.Services.Interfaces;
using PointOfSale.Utils;

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

  public async Task Register(RegisterRequestDto registerDto)
  {
    string passwordHash = Security.EncodeBcrypt(registerDto.Password!);
    if (await _userRepository.ExistsEmail(registerDto.Email!))
    {
      throw new Exception("Email already exists");
    }
    User user = new User(registerDto.Name, registerDto.Email, passwordHash);
    await _authRepository.Register(user);
  }

  public async Task<string> Login(LoginRequestDto loginDto)
  {
    User? user = await _userRepository.GetUserByEmail(loginDto.Email!);
    if (user == null)
    {
      throw new Exception("User not found");
    }
    if (!Security.VerifyBcrypt(loginDto.Password!, user.Password!))
    {
      throw new Exception("Invalid password");
    }
    return Security.GenerateJwtToken(user);
  }
}