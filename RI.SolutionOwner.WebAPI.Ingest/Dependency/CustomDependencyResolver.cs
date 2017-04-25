using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using RI.SolutionOwner.WebAPI.Ingest.Extensions;

namespace RI.SolutionOwner.WebAPI.Ingest.Dependency
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;

        public CustomDependencyResolver(IServiceCollection _serviceCollection)
        {
            this._serviceCollection = _serviceCollection;
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            _serviceCollection.AddSingleton(typeof(IServiceProvider), (p) => { return p; });

            // To get the service provider globally
            GetServiceLocator.Instance = _serviceProvider;
        }

        public IDependencyScope BeginScope()
        {
            return new CustomDependencyScope(_serviceProvider);
        }

        public void Dispose()
        {
            //TODO
        }

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
    }
}