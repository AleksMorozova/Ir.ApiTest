using Ir.IntegrationTest.Entity;
using Ir.IntegrationTest.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Ir.ApiTest.Repositories;
public interface IProductRepostory
{
  public Task AddProduct(Product product);
  public Task UpdateProduct(Product product);
  public Task<Product> GetProduct(string id); 
  public List<Product> GetAllProducts();
}

public class ProductRepostory: IProductRepostory
{
  public readonly Context _context;

  public ProductRepostory(Context context)
  {
    _context = context;
  }

  public async Task AddProduct(Product product)
  {
    await _context.Products.AddAsync(product);
    await _context.SaveChangesAsync();
  }

  public Task<Product> GetProduct(string id)
  {
    return _context.Products.FirstOrDefaultAsync(_ => _.Id.Equals(id));
  }

  public List<Product> GetAllProducts()
  {
    return _context.Products.ToList();
  }

  public async Task UpdateProduct(Product product)
  {
    _context.Products.Attach(product);
    _context.Entry(product).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }
}
