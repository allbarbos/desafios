using inGaia.Pizzaria.Domain.Entities;
using inGaia.Pizzaria.Domain.Interfaces.Application;
using System.Collections.Generic;

namespace inGaia.Pizzaria.Application.Services
{
  public class PedidoApplication: IPedidoApplication
  {
    public Pedido Checkout(IList<Pizza> pizzas)
    {
      var pedido = new Pedido(pizzas);
      pedido.ValidaPromocao();
      pedido.ValidaPedido();

      return pedido;
    }
  }
}
