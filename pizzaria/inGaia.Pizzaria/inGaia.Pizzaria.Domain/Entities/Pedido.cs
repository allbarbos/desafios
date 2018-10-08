using System;
using System.Collections.Generic;
using System.Linq;

namespace inGaia.Pizzaria.Domain.Entities
{
  public class Pedido
  {
    public Pedido(IEnumerable<Pizza> pizzas)
    {
      DataPedido = DateTime.Now.Date;
      Pizzas = pizzas;
      TaxaEntrega = 6.00;
      CalculaValorTotal();
    }

    public DateTime DataPedido { get; private set; }
    public IEnumerable<Pizza> Pizzas { get; private set; }
    public double TaxaEntrega { get; private set; }
    public double Total { get; private set; }

    public void SetaDataPedido(DateTime data)
    {
      DataPedido = data;
    }

    public void CalculaValorTotal()
    {
      var pizza = Pizzas.Sum(p => p.Valor);

      Total = pizza + TaxaEntrega;
    }

    public void ValidaPedido()
    {
      if (Pizzas == null || !Pizzas.Any())
        throw new InvalidOperationException("O itens do pedido não podem ser nulos ou vazio");

      if (TaxaEntrega == null)
        throw new InvalidOperationException("A taxa de entrega do pedido não podem ser nula");

      if (Total == 0)
        throw new InvalidOperationException("O total do pedido não podem ser R$ 0.00");
    }

    public void ValidaPromocao()
    {
      DescontoPorTaxaEntrega();

      DescontoPorTamanhoFamilia();

      DescontoPorTipoPromocao();
    }

    private void DescontoPorTamanhoFamilia()
    {
      // Grande Pedido - No pedido de 4 pizzas juntas a pizza com menor valor é grátis.
      if (Pizzas.Count() < 4)
        return;

      Pizzas = Pizzas.OrderBy(x => x.Valor);
      Pizzas.First().SetaValorTotal(0.00);

      CalculaValorTotal();
    }

    private void DescontoPorTaxaEntrega()
    {// Taxa de entrega - Se o pedido for feito na segunda, terça ou quarta-feira a taxa de entrega é grátis
      if (DataPedido.DayOfWeek != DayOfWeek.Monday
          && DataPedido.DayOfWeek != DayOfWeek.Tuesday
          && DataPedido.DayOfWeek != DayOfWeek.Wednesday)
        return;

      TaxaEntrega = 0.00;
      CalculaValorTotal();
    }

    private void DescontoPorTipoPromocao()
    {
      foreach (var pizza in Pizzas)
      {
        var carnes = pizza.Ingredientes.Count(ingrediente =>
          ingrediente.Nome.Equals("Calabresa") || ingrediente.Nome.Equals("Pepperoni") ||
          ingrediente.Nome.Equals("Presunto"));

        if (carnes == 0)
        {
          Total -= Total * 0.1; // Vegetariana - Se a pizza não contiver calabresa, pepperoni e presunto ganha 10% de desconto.
        }
        else if (carnes == 3)
        {
          Total -= Total * 0.2; // Carnívora - Se a pizza contiver os 3 tipos de carne (Pepperoni, Presunto e Calabresa) ganha 20% de desconto.
        }
      }
    }
  }
}
