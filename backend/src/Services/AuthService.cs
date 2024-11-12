using PointOfSale.DTO.Request;
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

  public async Task Register(RegisterRequestDto registerRequestDto)
  {
    string passwordHash = Security.EncodeBcrypt(registerRequestDto.Password!);
    if (await _userRepository.ExistsEmail(registerRequestDto.Email!))
    {
      throw new Exception("Email already exists");
    }
    User user = new User(registerRequestDto.Name, registerRequestDto.Email, passwordHash);
    await _authRepository.Register(user);
  }

  public async Task<string> Login(LoginRequestDto loginRequestDto)
  {
    User? user = await _userRepository.GetUserByEmail(loginRequestDto.Email!);
    if (user == null)
    {
      throw new Exception("User not found");
    }
    if (!Security.VerifyBcrypt(loginRequestDto.Password!, user.Password!))
    {
      throw new Exception("Invalid password");
    }
    return Security.GenerateJwtToken(user);
  }
}