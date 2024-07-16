using AutoMapper;

namespace Ir.ApiTest.Config;

public class AutoMapping : Profile
{
  public AutoMapping()
  {
    CreateMap<IntegrationTest.Contracts.Product, IntegrationTest.Entity.Models.Product>();
    CreateMap<IntegrationTest.Entity.Models.Product, IntegrationTest.Contracts.Product>();
  }
}
