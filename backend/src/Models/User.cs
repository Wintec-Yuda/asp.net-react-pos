using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models;
public class User
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
  public string? Username { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; } // Password yang di-hash
  public string? Role { get; set; } // Role, bisa "USER" atau "ADMIN"
  public List<Transaction>? Transactions { get; set; } = new List<Transaction>();
}
