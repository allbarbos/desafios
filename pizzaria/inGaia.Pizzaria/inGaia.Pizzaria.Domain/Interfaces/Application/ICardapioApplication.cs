using System.Collections.Generic;
using inGaia.Pizzaria.Domain.Entities;

namespace inGaia.Pizzaria.Domain.Interfaces.Application
{
  public interface ICardapioApplication
  {
    IList<Pizza> BuscaPizzas();
    IList<Ingrediente> BuscaIngredientes();
  }
}
