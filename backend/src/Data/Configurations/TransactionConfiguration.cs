using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointOfSale.Models;

namespace PointOfSale.Data.Configurations;
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
  public void Configure(EntityTypeBuilder<Transaction> builder)
  {
    // Tambahkan konfigurasi untuk entitas Transaction di sini jika diperlukan
    // Generate UUID secara otomatis
    builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");
    // Relasi One-to-Many antara Transaction dan TransactionItem
    builder.HasMany(t => t.TransactionItems)
        .WithOne(ti => ti.Transaction)
        .HasForeignKey(ti => ti.TransactionId); // Foreign key di TransactionItem
  }
}
