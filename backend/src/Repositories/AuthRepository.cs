using PointOfSale.Data;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;

namespace PointOfSale.Repositories;

public class AuthRepository : IAuthRepository
{
  private readonly AppDbContext _context;
  public AuthRepository(AppDbContext context) => _context = context;

  public Task<User> Register(User user)
  {
    _context.Users.Add(user);
    _context.SaveChanges();
    return Task.FromResult(user);
  }
}