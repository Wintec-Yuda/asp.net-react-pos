using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointOfSale.Models;

namespace PointOfSale.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    // Tambahkan konfigurasi untuk entitas TransactionItem di sini jika diperlukan
    // Generate UUID secara otomatis
    builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");
    // Atur default role
    builder.Property(u => u.Role).HasDefaultValue("USER");
    // Relasi One-to-Many antara User dan Transaction
    builder.HasMany(u => u.Transactions)
        .WithOne(t => t.User)
        .HasForeignKey(t => t.UserId);  // Foreign key di Transaction
  }
}
