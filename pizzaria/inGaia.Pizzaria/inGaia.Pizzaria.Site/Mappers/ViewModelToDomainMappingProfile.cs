using System;
using System.Globalization;
using AutoMapper;
using inGaia.Pizzaria.Domain.Entities;
using inGaia.Pizzaria.Site.ViewModel;

namespace inGaia.Pizzaria.Site.Mappers
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public override string ProfileName => "ViewModelToDomainMappings";

    public ViewModelToDomainMappingProfile()
    {
      CreateMap<FinalizarCompraIngredientePostModel, Ingrediente>();

      CreateMap<FinalizarCompraPizzaPostModel, Pizza>()
        .ForMember(
          dest => dest.Valor,
          opt => opt.MapFrom(src => Convert.ToDouble(src.valor, new CultureInfo("en-US")))
        );
    }
  }
}