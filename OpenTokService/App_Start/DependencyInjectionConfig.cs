using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OpenTokService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OpenTokService.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();
            
            //API
            builder.RegisterType<Services.OpenTokService>().As<IOpenTokService>().SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //MVC
            builder.RegisterType<Services.HttpClientService>().As<IHttpClientService>().SingleInstance();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}