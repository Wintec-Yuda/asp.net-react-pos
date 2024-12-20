using PointOfSale.Models;

namespace PointOfSale.Repositories.Interfaces;

public interface IUserRepository
{
  Task<bool> ExistsEmail(string email);
  Task<User?> GetUserByEmail(string email);
}