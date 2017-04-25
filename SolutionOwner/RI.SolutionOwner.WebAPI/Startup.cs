//---------------------------------------------------------------
// <copyright file="Startup.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System.Web.Http;
using Microsoft.Framework.DependencyInjection;
using Owin;
using RI.SolutionOwner.WebAPI.Dependency;
using RI.SolutionOwner.WebAPI.Extensions;

namespace RI.SolutionOwner.WebAPI
{
    /// <summary>
    /// Startup class for WebAPI
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
            GlobalConfiguration.Configuration.DependencyResolver = new CustomDependencyResolver(serviceCollection);
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
