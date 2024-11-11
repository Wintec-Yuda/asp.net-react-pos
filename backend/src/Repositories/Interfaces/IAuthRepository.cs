using PointOfSale.Models;

namespace PointOfSale.Repositories.Interfaces
{
  public interface IAuthRepository
  {
    Task Register(User user);
  }
}