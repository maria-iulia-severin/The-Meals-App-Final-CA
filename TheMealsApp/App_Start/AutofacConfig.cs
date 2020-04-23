using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TheMealsApp.DataModel;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WebApi;
using AutoMapper;

namespace TheMealsApp.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder bldr)
        {
            //Mapping to use it with my dependency injection 
            var config = new MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new MealsMappingProfile());
           });


            bldr.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();
            bldr.RegisterType<MealsContext>()
              .InstancePerRequest();

            bldr.RegisterType<MealsRepository>()
              .As<IMealsRepository>()
              .InstancePerRequest();
        }
    }
}