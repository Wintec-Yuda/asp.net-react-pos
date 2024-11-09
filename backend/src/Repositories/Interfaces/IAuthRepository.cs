using PointOfSale.Models;

namespace PointOfSale.Repositories.Interfaces
{
  public interface IAuthRepository
  {
    Task<User> Register(User user);
  }
}