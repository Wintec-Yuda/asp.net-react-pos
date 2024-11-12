using PointOfSale.DTO.Request;
using PointOfSale.Models;

namespace PointOfSale.Services.Interfaces;

public interface IProductService
{
  public Task<IEnumerable<Product>> GetProducts();
  public Task<Product?> GetProductById(Guid id);
  public Task CreateProduct(ProductRequestDto productRequestDto);
  public Task UpdateProduct(Guid id, ProductRequestDto productRequestDto);
  public Task DeleteProduct(Guid id);
}