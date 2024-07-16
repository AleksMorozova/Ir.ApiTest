using AutoMapper;
using Ir.ApiTest.Repositories;
using Ir.IntegrationTest.Contracts;

namespace Ir.ApiTest.Sevices;
public interface IProductService
{
  public Task AddProduct(IntegrationTest.Contracts.Product product); 
  public Task UpdateProduct(IntegrationTest.Contracts.Product product);

  public Task<IntegrationTest.Contracts.Product> GetProduct(string id);
  public List<IntegrationTest.Contracts.Product> GetAllProducts();
}

public class ProductService : IProductService
{
  private IProductRepostory _productRepostory;
  private readonly IMapper _mapper;

  public ProductService(IProductRepostory productRepostory, IMapper mapper)
  {
    _productRepostory = productRepostory; 
    _mapper = mapper;
  }

  public Task AddProduct(IntegrationTest.Contracts.Product product)
  {
    return _productRepostory.AddProduct(_mapper.Map<IntegrationTest.Entity.Models.Product>(product));
  }

  public List<IntegrationTest.Contracts.Product> GetAllProducts()
  {
    return _mapper.Map<List<IntegrationTest.Entity.Models.Product>, List<IntegrationTest.Contracts.Product>>(_productRepostory.GetAllProducts());
  }

  public async Task<IntegrationTest.Contracts.Product> GetProduct(string id)
  {
    var product = await _productRepostory.GetProduct(id);
    return _mapper.Map<IntegrationTest.Contracts.Product>(product);
  }

  public Task UpdateProduct(Product product)
  {
    return _productRepostory.UpdateProduct(_mapper.Map<IntegrationTest.Entity.Models.Product>(product));
  }
}
