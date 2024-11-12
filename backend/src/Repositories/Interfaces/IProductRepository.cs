using PointOfSale.DTO.Request;
using PointOfSale.Models;

namespace PointOfSale.Repositories.Interfaces;

public interface IProductRepository
{
  Task<IEnumerable<Product>> GetProducts();
  Task<Product?> GetProductById(Guid id);
  Task CreateProduct(Product product);
  Task UpdateProduct(Product product, ProductRequestDto productRequestDto);
  Task DeleteProduct(Product product);
}