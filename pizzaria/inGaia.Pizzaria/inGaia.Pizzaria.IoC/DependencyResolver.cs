using inGaia.Pizzaria.Application.Services;
using inGaia.Pizzaria.Domain.Interfaces.Application;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace inGaia.Pizzaria.IoC
{
  public static class DependencyResolver
  {

    public static void SiteResolve(UnityContainer container)
    {
      container.RegisterType<ICardapioApplication, CardapioApplication>(new HierarchicalLifetimeManager());
      container.RegisterType<IPedidoApplication, PedidoApplication>(new HierarchicalLifetimeManager());

      System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
  }
}
