using inGaia.Pizzaria.Domain.Entities;
using System.Collections.Generic;

namespace inGaia.Pizzaria.Domain.Interfaces.Application
{
  public interface IPedidoApplication
  {
    Pedido Checkout(IList<Pizza> pizzas);
  }
}
