using System.Collections.Generic;
using inGaia.Pizzaria.Domain.Entities;

namespace inGaia.Pizzaria.Domain.Factory
{
  public class PizzaFactory
  {
    public Pizza Marguerita()
    {
      var massaTradicional = new Ingrediente("Massa Tradicional", 5.00);
      var queijo = new Ingrediente("Queijo", 2.00);
      var tomate = new Ingrediente("Tomate", 3.80);
      var manjericao = new Ingrediente("Manjericão", 3.80);

      var ingredientes = new List<Ingrediente>
      {
        massaTradicional,
        queijo,
        tomate,
        manjericao
      };

      return new Pizza("Marguerita", ingredientes);
    }

    public Pizza Calabresa()
    {
      var massaFina = new Ingrediente("Massa fina", 5.00);
      var queijo = new Ingrediente("Queijo", 2.00);
      var tomate = new Ingrediente("Tomate", 3.80);
      var calabresa = new Ingrediente("Calabresa", 5.80);

      var ingredientes = new List<Ingrediente>
      {
        massaFina,
        calabresa,
        tomate,
        queijo
      };

      return new Pizza("Calabresa", ingredientes);
    }

    public Pizza CalabresaTresCarnes()
    {
      var massaFina = new Ingrediente("Massa fina", 5.00);
      var queijo = new Ingrediente("Queijo", 2.00);
      var tomate = new Ingrediente("Tomate", 3.80);
      var calabresa = new Ingrediente("Calabresa", 5.80);
      var presunto = new Ingrediente("Presunto", 5.80);
      var pepperoni = new Ingrediente("Pepperoni", 5.80);

      var ingredientes = new List<Ingrediente>
      {
        massaFina,
        tomate,
        queijo,
        calabresa,
        presunto,
        pepperoni
      };

      return new Pizza("Calabresa", ingredientes);
    }

    public Pizza Portuguesa()
    {
      var massaTradicional = new Ingrediente("Massa Tradicional", 5.00);
      var queijo = new Ingrediente("Queijo", 2.00);
      var tomate = new Ingrediente("Tomate", 3.80);
      var ovo = new Ingrediente("Ovo", 5.80);
      var cebola = new Ingrediente("Cebola", 5.80);
      var palmito = new Ingrediente("Palmito", 5.80);
      var presunto = new Ingrediente("Presunto", 5.80);
      var ervilha = new Ingrediente("Ervilha", 5.80);

      var ingredientes = new List<Ingrediente>
      {
        massaTradicional,
        ovo,
        tomate,
        cebola,
        queijo,
        palmito,
        presunto,
        ervilha
      };

      return new Pizza("Portuguesa", ingredientes);
    }

    public Pizza Pepperoni()
    {
      var massaPan = new Ingrediente("Massa Pan", 5.00);
      var queijo = new Ingrediente("Queijo", 2.00);
      var tomate = new Ingrediente("Tomate", 3.80);
      var pepperoni = new Ingrediente("Pepperoni", 5.80);

      var ingredientes = new List<Ingrediente>
      {
        massaPan,
        pepperoni,
        queijo,
        tomate
      };

      return new Pizza("Pepperoni", ingredientes);
    }

    public IList<Pizza> GeraPizzas()
    {
      return new List<Pizza>
      {
        Marguerita(),
        Calabresa(),
        Portuguesa(),
        Pepperoni()
      };
    }

    public IList<Ingrediente> GeraIngredientes()
    {
      var ingredientes = new List<Ingrediente>
      {
        new Ingrediente("Massa Tradicional", 8.00),
        new Ingrediente("Massa fina", 12.00),
        new Ingrediente("Massa Pan", 15.00),
        new Ingrediente("Queijo", 2.00),
        new Ingrediente("Tomate", 3.80),
        new Ingrediente("Manjericão", 3.80),
        new Ingrediente("Calabresa", 5.80),
        new Ingrediente("Ovo", 5.80),
        new Ingrediente("Cebola", 5.80),
        new Ingrediente("Palmito", 5.80),
        new Ingrediente("Presunto", 5.80),
        new Ingrediente("Ervilha", 5.80),
        new Ingrediente("Pepperoni", 5.80)
      };

      return ingredientes;
    }
  }
}
