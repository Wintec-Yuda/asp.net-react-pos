using PointOfSale.DTO.Request;
using PointOfSale.Models;
using PointOfSale.Repositories.Interfaces;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Services;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepository;

  public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

  public async Task<IEnumerable<Product>> GetProducts()
  {
    return await _productRepository.GetProducts();
  }

  public async Task<Product?> GetProductById(Guid id)
  {
    return await _productRepository.GetProductById(id);
  }

  public async Task CreateProduct(ProductRequestDto productRequestDto)
  {
    Product product = new()
    {
      Name = productRequestDto.Name,
      Price = productRequestDto.Price,
      Stock = productRequestDto.Stock
    };
    
    await _productRepository.CreateProduct(product);
  }

  public async Task UpdateProduct(Guid id, ProductRequestDto productRequestDto)
  {
    Product? product = await _productRepository.GetProductById(id);

    if (product == null)
    {
      throw new Exception("Product not found");
    }

    await _productRepository.UpdateProduct(product, productRequestDto);
  }

  public async Task DeleteProduct(Guid id)
  {
    Product? product = await _productRepository.GetProductById(id);

    if (product == null)
    {
      throw new Exception("Product not found");
    }

    await _productRepository.DeleteProduct(product);
  }
}