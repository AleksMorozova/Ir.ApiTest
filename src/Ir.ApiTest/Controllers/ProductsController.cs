using Ir.ApiTest.Sevices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Product = Ir.IntegrationTest.Contracts.Product;

namespace Ir.FakeMarketplace.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private IProductService _productService;

  public ProductsController(IProductService productService)
  {
    _productService = productService;
  }

  [HttpGet]
  public IEnumerable<Product> GetProducts()
  {
    return _productService.GetAllProducts();
  }

  [HttpGet("{id}")]
  public IActionResult GetProduct([FromRoute]string id)
  {
    var product = _productService.GetProduct(id);
    return product!= null ? Ok(product) : NotFound();
  }

  [HttpPost()]
  public IActionResult CreateProduct([FromBody] Product product)
  {
    _productService.AddProduct(product);
    return Ok(product);
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument<Product> productPatchDocument)
  {
    string id = RouteData.Values["id"].ToString();

    var product = await _productService.GetProduct(id);

    productPatchDocument.ApplyTo(product);

    await _productService.UpdateProduct(product);

    return Ok();
  }
}