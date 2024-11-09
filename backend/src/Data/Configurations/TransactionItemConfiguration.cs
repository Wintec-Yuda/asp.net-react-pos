using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointOfSale.Models;

namespace PointOfSale.Data.Configurations;
public class TransactionItemConfiguration : IEntityTypeConfiguration<TransactionItem>
{
  public void Configure(EntityTypeBuilder<TransactionItem> builder)
  {
    // Tambahkan konfigurasi untuk entitas TransactionItem di sini jika diperlukan
    // Generate UUID secara otomatis
    builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");
    // Relasi One-to-Many antara TransactionItem dan Transaction
    builder.HasOne(ti => ti.Transaction)
        .WithMany(t => t.TransactionItems)
        .HasForeignKey(ti => ti.TransactionId);  // Foreign key di TransactionItem Relasi One-to-Many antara TransactionItem dan Product
    builder.HasOne(ti => ti.Product)
        .WithMany(p => p.TransactionItems)
        .HasForeignKey(ti => ti.ProductId);  // Foreign key di TransactionItem
  }
}
