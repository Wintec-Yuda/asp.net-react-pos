namespace PointOfSale.Models;
public class TransactionItem
{
  public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key
  public Guid TransactionId { get; set; } // Foreign Key ke Transaction
  public Transaction? Transaction { get; set; } // Relasi ke Transaction
  public Guid ProductId { get; set; } // Foreign Key ke Product
  public Product? Product { get; set; } // Relasi ke Product
  public int Quantity { get; set; } // Jumlah produk dalam transaksi ini
  public decimal Price { get; set; } // Harga per unit produk pada saat transaksi
}
