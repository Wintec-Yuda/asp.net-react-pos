using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Data.Configurations;

namespace PointOfSale.Data;
public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Transaction> Transactions { get; set; }
  public DbSet<TransactionItem> TransactionItems { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new UserConfiguration());
    modelBuilder.ApplyConfiguration(new ProductConfiguration());
    modelBuilder.ApplyConfiguration(new TransactionConfiguration());
    modelBuilder.ApplyConfiguration(new TransactionItemConfiguration());
  }
}
