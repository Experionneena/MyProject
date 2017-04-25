using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace RI.SolutionOwner.WebAPI.Ingest.Dependency
{
    public class CustomDependencyScope : IDependencyScope
    {
        private IServiceProvider _serviceProvider;

        public CustomDependencyScope(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            //TODO
        }

        public object GetService(Type serviceType)
        {
            var instance = _serviceProvider.GetService(serviceType);
            if (null == instance)
            {
                instance = ActivatorUtilities.CreateInstance(_serviceProvider, serviceType);
            }
            return instance;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}