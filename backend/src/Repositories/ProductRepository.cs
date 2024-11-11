using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;
using PointOfSale.DTO;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;

namespace PointOfSale.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly AppDbContext _context;
  public ProductRepository(AppDbContext context) => _context = context;

  public async Task<IEnumerable<Product>> GetProducts()
  {
    return await _context.Products.ToListAsync();
  }

  public async Task<Product?> GetProductById(Guid id)
  {
    return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
  }

  public async Task CreateProduct(Product product)
  {
    _context.Products.Add(product);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateProduct(Product product, ProductRequestDto productDto)
  {
    product.Name = productDto.Name;
    product.Price = productDto.Price;

    await _context.SaveChangesAsync();
  }
  public async Task DeleteProduct(Product product)
  {
    _context.Products.Remove(product);
    await _context.SaveChangesAsync();
  }

}