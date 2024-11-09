namespace PointOfSale.Models;
public class Transaction
{
  public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
  public Guid UserId { get; set; } // Foreign Key ke User
  public User? User { get; set; } // Relasi ke User
  public decimal TotalAmount { get; set; }
  public DateTime Date { get; set; } // Tanggal transaksi
  public List<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
