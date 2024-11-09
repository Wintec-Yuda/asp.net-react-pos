using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models;
public class User
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
  public string? Username { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; } // Password yang di-hash
  public string? Role { get; set; } = "USER"; // Role, bisa "USER" atau "ADMIN"
  public List<Transaction>? Transactions { get; set; } = new List<Transaction>();

  public User(string? username, string? email, string? password)
  {
    Username = username;
    Email = email;
    Password = password;
  }
}
