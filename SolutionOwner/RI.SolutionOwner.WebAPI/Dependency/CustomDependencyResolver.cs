//-----------------------------------------------------------
// <copyright file="CustomDependencyResolver.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Framework.DependencyInjection;
using RI.SolutionOwner.WebAPI.Extensions;

namespace RI.SolutionOwner.WebAPI.Dependency
{
    /// <summary>
    /// CustomDependencyResolver class
    /// </summary>
    public class CustomDependencyResolver : IDependencyResolver
    {
        #region Private Members
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;
        #endregion


        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDependencyResolver" /> class.
        /// </summary>
        /// <param name="_serviceCollection">The _service collection.</param>
        public CustomDependencyResolver(IServiceCollection _serviceCollection)
        {
            this._serviceCollection = _serviceCollection;
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            _serviceCollection.AddSingleton(typeof(IServiceProvider), (p) => { return p; });

            //// To get the service provider globally
            GetServiceLocator.Instance = _serviceProvider;
        }

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return new CustomDependencyScope(_serviceProvider);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            ////TODO
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns> object </returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return _serviceProvider.GetService(serviceType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>List of object</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _serviceProvider.GetServices(serviceType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}