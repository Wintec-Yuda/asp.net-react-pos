namespace PointOfSale.Repositories.Interfaces;

public interface IUserRepository
{
  Task<bool> ExistsEmail(string email);
}