using AutoMapper;
using inGaia.Pizzaria.Domain.Entities;
using inGaia.Pizzaria.Site.ViewModel;

namespace inGaia.Pizzaria.Site.Mappers
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public override string ProfileName => "DomainToViewModelMappings";

    public DomainToViewModelMappingProfile()
    {
      CreateMap<Ingrediente, FinalizarCompraIngredientePostModel>();
      CreateMap<Pizza, FinalizarCompraPizzaPostModel>();
    }
  }
}