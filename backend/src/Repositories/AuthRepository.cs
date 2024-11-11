using PointOfSale.Data;
using PointOfSale.DTO;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;

namespace PointOfSale.Repositories;

public class AuthRepository : IAuthRepository
{
  private readonly AppDbContext _context;
  public AuthRepository(AppDbContext context) => _context = context;

  public async Task Register(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
  }

}