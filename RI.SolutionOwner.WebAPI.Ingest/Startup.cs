using Microsoft.Framework.DependencyInjection;
using Owin;
using RI.SolutionOwner.WebAPI.Ingest.Dependency;
using RI.SolutionOwner.WebAPI.Ingest.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.FabricServiceHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RI.SolutionOwner.WebAPI.Ingest
{
    public class Startup : IOwinAppBuilder
    {
        public static void ConfigureFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            formatters.JsonFormatter
                       .SerializerSettings
                       .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ConfigureFormatters(config.Formatters);
           

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional });
            appBuilder.UseWebApi(config);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            config.DependencyResolver = new CustomDependencyResolver(serviceCollection);

        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataLayer();
            serviceCollection.AddBusinessServiceLayer();
            serviceCollection.AddDataServiceLayer();
            serviceCollection.AddManualRegistration();
            serviceCollection.AddMappers(typeof(Startup));
        }
    }
}
