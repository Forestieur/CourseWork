namespace HotelApp
{
    using Ninject;
    using Ninject.Web.Mvc;
    using Ninject.Modules;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using HotelApp.BLL.Infrastructure;
  

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule hotelModule = new HotelModule();
            NinjectModule serviceModule = new ServiceModule("connection");
            IKernel kernel = new StandardKernel(hotelModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            kernel.Unbind<ModelValidatorProvider>();
        }
    }
}
