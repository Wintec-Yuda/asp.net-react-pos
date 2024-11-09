using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointOfSale.Models;

namespace PointOfSale.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    // Tambahkan konfigurasi untuk entitas Product di sini jika diperlukan
    // Generate UUID secara otomatis
    builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");
    // Relasi One-to-Many antara Product dan TransactionItem
            builder.HasMany(p => p.TransactionItems)
                .WithOne(ti => ti.Product)
                .HasForeignKey(ti => ti.ProductId); // Foreign key di TransactionItem
  }
}
