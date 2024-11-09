using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.Repositories.Interfaces;

namespace PointOfSale.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;
  public UserRepository(AppDbContext context) => _context = context;

  public async Task<bool> ExistsEmail(string email)
  {
    return await _context.Users.AnyAsync(u => u.Email == email);
  }
}