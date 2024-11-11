using PointOfSale.DTO;
using PointOfSale.Models;

namespace PointOfSale.Repositories.Interfaces;

public interface IProductRepository
{
  Task<IEnumerable<Product>> GetProducts();
  Task<Product?> GetProductById(Guid id);
  Task CreateProduct(Product product);
  Task UpdateProduct(Product product, ProductRequestDto productDto);
  Task DeleteProduct(Product product);
}