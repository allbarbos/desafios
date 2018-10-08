using System.Collections.Generic;

namespace inGaia.Pizzaria.Site.ViewModel
{
  public class FinalizarCompraPedidoModel
  {
    public List<FinalizarCompraPizzaPostModel> pizzas { get; set; }
    public string total { get; set; }
  }

  public class FinalizarCompraPizzaPostModel
  {
    public string nome { get; set; }
    public string valor { get; set; }
    public List<FinalizarCompraIngredientePostModel> ingredientes { get; set; }
  }

  public class FinalizarCompraIngredientePostModel
  {
    public string nome { get; set; }
    public string valor { get; set; }
  }
}