using System.Collections.Generic;
using inGaia.Pizzaria.Domain.Entities;
using inGaia.Pizzaria.Domain.Factory;
using inGaia.Pizzaria.Domain.Interfaces.Application;
using System.Linq;

namespace inGaia.Pizzaria.Application.Services
{
  public class CardapioApplication : ICardapioApplication
  {
    public IList<Pizza> BuscaPizzas()
    {
      var pizzas = new PizzaFactory().GeraPizzas();

      foreach (var pizza in pizzas)
      {
        pizza.SetaIngredientesAdicionais(BuscaIngredientes());
      }

      return pizzas;
    }

    public IList<Ingrediente> BuscaIngredientes()
    {
      return new PizzaFactory().GeraIngredientes();
    }
  }
}
