using PointOfSale.DTO;
using PointOfSale.Models;

namespace PointOfSale.Services.Interfaces;

public interface IProductService
{
  public Task<IEnumerable<Product>> GetProducts();
  public Task<Product?> GetProductById(Guid id);
  public Task CreateProduct(ProductRequestDto productDto);
  public Task UpdateProduct(Guid id, ProductRequestDto productDto);
  public Task DeleteProduct(Guid id);
}