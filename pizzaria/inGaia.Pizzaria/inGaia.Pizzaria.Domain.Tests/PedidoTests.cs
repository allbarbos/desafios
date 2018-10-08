using System;
using System.Collections.Generic;
using System.Linq;
using inGaia.Pizzaria.Domain.Entities;
using inGaia.Pizzaria.Domain.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace inGaia.Pizzaria.Domain.Tests
{
  [TestClass]
  public class PedidoTests
  {
    [TestMethod]
    public void DeveValidarPromocaoVegetariana()
    {
      var pizzas = new List<Pizza> { new PizzaFactory().Marguerita() };

      var pedido = new Pedido(pizzas);
      var esperado = pizzas.Sum(p => p.Valor) - pizzas.Sum(p => p.Valor) * 0.1;

      pedido.ValidaPromocao();

      Assert.AreEqual(esperado, pedido.Total);
    }

    [TestMethod]
    public void DeveValidarPromocaoCarnivora()
    {
      var pizzas = new List<Pizza> { new PizzaFactory().CalabresaTresCarnes() };

      var pedido = new Pedido(pizzas);
      var esperado = pizzas.Sum(p => p.Valor) - pizzas.Sum(p => p.Valor) * 0.2;

      pedido.ValidaPromocao();

      Assert.AreEqual(esperado, pedido.Total);
    }

    [TestMethod]
    public void DeveValidarPromocaoTaxaEntregaGratis()
    {
      var pizzas = new List<Pizza> { new PizzaFactory().Portuguesa() };
      const int taxaEntrega = 0;

      var pedido = new Pedido(pizzas);
      pedido.SetaDataPedido(new System.DateTime(2018, 4, 9));

      var esperado = pizzas.Sum(p => p.Valor) + taxaEntrega;

      pedido.ValidaPromocao();

      Assert.AreEqual(esperado, pedido.Total);
    }

    [TestMethod]
    public void DeveValidarPromocaoTaxaEntregaCobrada()
    {
      var pizzas = new List<Pizza> { new PizzaFactory().Portuguesa() };
      const int taxaEntrega = 6;

      var pedido = new Pedido(pizzas);
      pedido.SetaDataPedido(new System.DateTime(2018, 4, 14));

      var esperado = pizzas.Sum(p => p.Valor) + taxaEntrega;

      pedido.ValidaPromocao();

      Assert.AreEqual(esperado, pedido.Total);
    }

    [TestMethod]
    public void DeveValidarPromocaoTamanhoFamiliaComTaxaEntrega()
    {
      var pizzas = new List<Pizza>
      {
        new PizzaFactory().Portuguesa(),
        new PizzaFactory().Calabresa(),
        new PizzaFactory().Calabresa(),
        new PizzaFactory().Pepperoni()
      };
      const int taxaEntrega = 6;

      var pedido = new Pedido(pizzas);
      pedido.SetaDataPedido(new DateTime(2018, 4, 14));

      pizzas = pedido.Pizzas.OrderBy(x => x.Valor).ToList();
      pizzas.First().SetaValorTotal(0.00);

      var esperado = pizzas.Sum(p => p.Valor) + taxaEntrega;

      pedido.ValidaPromocao();

      Assert.AreEqual(esperado, pedido.Total);
    }

    [TestMethod]
    public void DeveValidarPromocaoTamanhoFamiliaSemDescontoComTaxaEntrega()
    {
      var pizzas = new List<Pizza>
      {
        new PizzaFactory().Portuguesa(),
        new PizzaFactory().Calabresa(),
        new PizzaFactory().Pepperoni()
      };
      const int taxaEntrega = 6;

      var pedido = new Pedido(pizzas);
      pedido.SetaDataPedido(new DateTime(2018, 4, 14));
      
      var esperado = pizzas.Sum(p => p.Valor) + taxaEntrega;

      pedido.ValidaPromocao();

      Assert.AreEqual(esperado, pedido.Total);
    }

    [TestMethod]
    public void DeveValidarValorTotalPedido()
    {
      var pizzas = new List<Pizza>
      {
        new PizzaFactory().Portuguesa(),
        new PizzaFactory().Calabresa(),
        new PizzaFactory().Pepperoni()
      };
      const int taxaEntrega = 6;

      var pedido = new Pedido(pizzas);
      pedido.SetaDataPedido(new DateTime(2018, 4, 14));

      var esperado = pizzas.Sum(p => p.Valor) + taxaEntrega;

      pedido.CalculaValorTotal();

      Assert.AreEqual(esperado, pedido.Total);
    }
  }
}
