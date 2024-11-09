using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models;
public class Product
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
  public string? Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public List<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
