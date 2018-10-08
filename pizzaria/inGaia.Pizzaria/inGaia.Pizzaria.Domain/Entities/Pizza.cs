using System.Collections.Generic;
using System.Linq;

namespace inGaia.Pizzaria.Domain.Entities
{
  public class Pizza
  {
    protected Pizza() { }

    public Pizza(string nome, IList<Ingrediente> ingredientes)
    {
      Nome = nome;
      Ingredientes = ingredientes;
      Valor = CalculaValorTotal();
    }

    public string Nome { get; private set; }
    public double Valor { get; private set; }
    public IList<Ingrediente> Ingredientes { get; private set; }
    public IList<Ingrediente> IngredientesAdicionais { get; private set; }

    public void SetaValorTotal(double valor)
    {
      Valor = valor;
    }

    public void SetaIngredientesAdicionais(IList<Ingrediente> ingredientesAdicionais)
    {
      foreach (var ingrediente in Ingredientes)
      {
        var remove = ingredientesAdicionais.First(i => i.Nome == ingrediente.Nome);
        ingredientesAdicionais.Remove(remove);
      }

      IngredientesAdicionais = ingredientesAdicionais;
    }

    public double CalculaValorTotal()
    {
      return Ingredientes.Sum(ingrediente => ingrediente.Valor);
    }

    public void AdicionarIngrediente(Ingrediente ingrediente)
    {
      Ingredientes.Add(ingrediente);
      CalculaValorTotal();
    }
  }
}
