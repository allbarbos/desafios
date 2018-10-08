namespace inGaia.Pizzaria.Domain.Entities
{
  public class Ingrediente
  {
    public Ingrediente(string nome, double valor)
    {
      Nome = nome;
      Valor = valor;
    }

    public string Nome { get; private set; }
    public double Valor { get; private set; }

    public void SetaValor(double valor)
    {
      Valor = valor;
    }
  }
}
