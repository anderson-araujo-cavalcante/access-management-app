using AleffGroup.Application.AppServices;
using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Domain.Interfaces.Services;
using AleffGroup.Domain.Services;
using AleffGroup.Infra.Data.Repositories;
using AleffGroup.WebMvc.AutoMapper;
using AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AleffGroup.WebMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //container.Register<IHttpContextAccessor, HttpContextAccessor>(Lifestyle.Singleton);


            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<ILogAccessRepository, LogAccessRepository>(Lifestyle.Scoped);            
           
            container.Register<ILoginAppService, LoginAppService>(Lifestyle.Scoped);
            container.Register<IUserAppService, UserAppService>(Lifestyle.Scoped);
            container.Register<ILogAccessAppService, LogAccessAppService>(Lifestyle.Scoped);

            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<ILogAccessService, LogAccessService>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            var config = AutoMapperConfig.RegisterMappings();
            IMapper mapper = config.CreateMapper();
            container.RegisterInstance<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));

            container.Verify();

            DependencyResolver.SetResolver(
               new SimpleInjectorDependencyResolver(container));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
