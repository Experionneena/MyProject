//---------------------------------------------------------------
// <copyright file="Startup.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Web.Mvc;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Owin;
using Owin;
using RI.SolutionOwner.Web.Extensions;
using Microsoft.Extensions.Logging;

[assembly: OwinStartupAttribute(typeof(RI.SolutionOwner.Web.Startup))]

namespace RI.SolutionOwner.Web
{
    /// <summary>
    /// Startup class for Web
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ////GlobalConfiguration.Configuration.DependencyResolver = new CustomDependencyResolver(serviceCollection);
            DependencyResolver.SetResolver((IDependencyResolver)new CustomDependencyResolver(serviceCollection));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataLayer();
            serviceCollection.AddManualRegistration();
            serviceCollection.AddMappers(typeof(Startup));

            ////serviceCollection.AddLogging();
            ////var loggerFactory = (ILoggerFactory)serviceCollection.BuildServiceProvider().GetService(typeof(ILoggerFactory));
            ////loggerFactory.AddProvider(new Log4NetProvider());
        }
    }
}
