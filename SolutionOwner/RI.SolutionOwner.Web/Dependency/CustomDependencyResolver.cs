//-----------------------------------------------------------
// <copyright file="CustomDependencyResolver.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace RI.SolutionOwner.Web.Extensions
{
    /// <summary>
    /// CustomDependencyResolver class
    /// </summary>
    public class CustomDependencyResolver : IDependencyResolver
    {
        #region Private Members        
        /// <summary>
        /// The service collection
        /// </summary>
        private IServiceCollection serviceCollection;

        /// <summary>
        /// The service provider
        /// </summary>
        private IServiceProvider serviceProvider;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDependencyResolver" /> class.
        /// </summary>
        /// <param name="serviceCollection">The _service collection.</param>
        public CustomDependencyResolver(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
            this.serviceProvider = serviceCollection.BuildServiceProvider();
            this.serviceCollection.AddSingleton(typeof(IServiceProvider), (p) => { return p; });
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>The object</returns>
        public object GetService(Type serviceType)
        {
            var instance = serviceProvider.GetService(serviceType);
            if (null == instance)
            {
                try
                {
                    instance = ActivatorUtilities.CreateInstance(serviceProvider, serviceType);
                }
                catch
                {
                    return null;
                }
            }

            return instance;
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>List of objects</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return serviceProvider.GetServices(serviceType);
        }
    }
}