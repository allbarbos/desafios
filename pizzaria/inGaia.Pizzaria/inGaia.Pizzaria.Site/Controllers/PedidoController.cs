using System.Collections.Generic;
using System.Web.Mvc;
using inGaia.Pizzaria.Domain.Entities;
using inGaia.Pizzaria.Domain.Interfaces.Application;
using inGaia.Pizzaria.Site.ViewModel;
using Newtonsoft.Json;
using System.Net;
using AutoMapper;

namespace inGaia.Pizzaria.Site.Controllers
{
  public class PedidoController : Controller
  {
    private readonly IPedidoApplication _pedidoApplication;

    public PedidoController(IPedidoApplication pedidoApplication)
    {
      _pedidoApplication = pedidoApplication;
    }

    [HttpPost]
    public JsonResult FinalizarCompra(string pedido)
    {
      try
      {
        var pizzas = SerializaJson(pedido);
        var pedidoFinal = _pedidoApplication.Checkout(pizzas);

        return Json(new { concluido = true, erro = string.Empty, pedido = pedidoFinal });
      }
      catch (System.Exception ex)
      {
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new { concluido = false, erro = ex.Message });
      }
    }

    public ActionResult Confirmacao()
    {
      return View();
    }

    private static List<Pizza> SerializaJson(string pedido)
    {
      var model = JsonConvert.DeserializeObject<FinalizarCompraPedidoModel>(pedido);
      var pizzas = Mapper.Map<List<FinalizarCompraPizzaPostModel>, List<Pizza>>(model.pizzas);

      return pizzas;
    }
  }
}