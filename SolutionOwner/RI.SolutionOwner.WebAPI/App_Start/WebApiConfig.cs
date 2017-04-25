//---------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace RI.SolutionOwner.WebAPI
{
    /// <summary>
    /// This class has WebAPI related configurations
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services
            //// Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //// Web API routes
            config.MapHttpAttributeRoutes();

            ////var serviceCollection = new ServiceCollection();
            ////serviceCollection.AddScoped<IAccountService, AccountService>();
            ////serviceCollection.BuildServiceProvider();


            //////  config.Routes.MapHttpRoute(
            //////name: "ApiById",
            //////routeTemplate: "api/{controller}/{action}/{id}",
            //////defaults: new { id = RouteParameter.Optional }
            //////    );

            //////  config.Routes.MapHttpRoute(
            //////      name: "ApiByAction",
            //////      routeTemplate: "api/{controller}/{action}",
            //////      defaults: new { action = "Get" }
            //////  );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional
                });
        }
    }
}
