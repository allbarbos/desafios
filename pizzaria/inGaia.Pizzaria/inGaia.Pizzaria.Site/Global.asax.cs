using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using inGaia.Pizzaria.Site.Mappers;
using Microsoft.Practices.Unity;

namespace inGaia.Pizzaria.Site
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      AutoMapperConfig.RegisterMappings();

      var container = new UnityContainer();
      IoC.DependencyResolver.SiteResolve(container);

      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
