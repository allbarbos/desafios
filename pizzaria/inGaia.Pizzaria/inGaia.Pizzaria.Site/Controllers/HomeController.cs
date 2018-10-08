using System.Web.Mvc;
using inGaia.Pizzaria.Domain.Interfaces.Application;

namespace inGaia.Pizzaria.Site.Controllers
{
  public class HomeController : Controller
  {
    private readonly ICardapioApplication _cardapioApplication;

    public HomeController(ICardapioApplication cardapioApplication)
    {
      _cardapioApplication = cardapioApplication;
    }

    public ActionResult Index()
    {
      ViewBag.Pizzas = _cardapioApplication.BuscaPizzas();
      ViewBag.Ingredientes = _cardapioApplication.BuscaIngredientes();

      return View();
    }
  }
}