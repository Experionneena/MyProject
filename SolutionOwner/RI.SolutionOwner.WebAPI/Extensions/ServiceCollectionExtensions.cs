//---------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.ModelBinding;
using Microsoft.Framework.DependencyInjection;
using RI.Framework.Audit.Abstraction;
using RI.Framework.Audit.EntityFramework;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.EntityFramework;
using RI.Framework.Core.Logging.Extensions;
using RI.SolutionOwner.Data;

namespace RI.SolutionOwner.WebAPI.Extensions
{
    /// <summary>
    /// This class maps the interfaces to the implementations in the WebAPI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the mappers.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="startupType">Type of the startup.</param>
        public static void AddMappers(this IServiceCollection services, Type startupType = null)
        {
            var mapperTypes = startupType.GetTypeInfo()
                .Assembly.ExportedTypes
                .Where(t => t.GetTypeInfo().BaseType?.Name == "ObjectMapper`2")
                .Select(x => new
                {
                    MapperType = x,
                    BaseType = x.GetTypeInfo().BaseType
                });

            foreach (var mapperType in mapperTypes)
            {
                services.AddTransient(mapperType.BaseType, mapperType.MapperType);
            }
        }

        //// Exception occurs when there may be wrong implementation 
        //// or not inherting the interface or wrong naming (mismatch in naming between interface and its implementation)

        /// <summary>
        /// Adds the data layer.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddDataLayer(this IServiceCollection services)
        {
            string dataAssemblyName = "RI.SolutionOwner.Data.dll";
            string dataassemblyPath = HttpContext.Current.Server.MapPath("~/bin/" + dataAssemblyName);
            Assembly dataRepositoryAssembly = Assembly.LoadFrom(dataassemblyPath);
            var dataRegistrations =
               from type in dataRepositoryAssembly.GetExportedTypes()
               where type.Namespace == "RI.SolutionOwner.Data.Entities"
               where type.GetInterfaces().Any()
               select new { Service = type.GetInterfaces().Where(x => x.Name.Contains(type.Name) && x.Name.StartsWith("I")).Single(), Implementation = type };

            // registering data layer in service collection
            foreach (var reg in dataRegistrations)
            {
                services.AddTransient(reg.Service, reg.Implementation);
            }
        }

        /// <summary>
        /// Adds the business service layer.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddBusinessServiceLayer(this IServiceCollection services)
        {
            string businessAssemblyName = "RI.SolutionOwner.Business.dll";
            string businessassemblyPath = HttpContext.Current.Server.MapPath("~/bin/" + businessAssemblyName);
            Assembly bussinessRepositoryAssembly = Assembly.LoadFrom(businessassemblyPath);
            var bussinessServiceRegistrations =
               from type in bussinessRepositoryAssembly.GetExportedTypes()
               where type.Namespace == "RI.SolutionOwner.Business"
               where type.GetInterfaces().Any()
               select new { Service = type.GetInterfaces().Where(x => x.Name.Contains(type.Name) && x.Name.StartsWith("I")).Single(), Implementation = type };

            // registering business service layer in service collection
            foreach (var reg in bussinessServiceRegistrations)
            {
                services.AddTransient(reg.Service, reg.Implementation);
            }
        }

        /// <summary>
        /// Adds the data service layer.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddDataServiceLayer(this IServiceCollection services)
        {
            string dataServiceAssemblyName = "RI.SolutionOwner.Data.Services.dll";
            string dataAccessAssemblyPath = HttpContext.Current.Server.MapPath("~/bin/" + dataServiceAssemblyName);
            Assembly dataServiceRepositoryAssembly = Assembly.LoadFrom(dataAccessAssemblyPath);
            var dataServiceRegistrations =
               from type in dataServiceRepositoryAssembly.GetExportedTypes()
               where type.Namespace == "RI.SolutionOwner.Data.Services"
               where type.GetInterfaces().Any()
               select new { Service = type.GetInterfaces().Where(x => x.Name.Contains(type.Name) && x.Name.StartsWith("I")).Single(), Implementation = type };
            // registering data service layer in service collection
            foreach (var reg in dataServiceRegistrations)
            {
                services.AddTransient(reg.Service, reg.Implementation);
            }
        }

        /// <summary>
        /// Adds the manual registration.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddManualRegistration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DbContext, SolutionOwnerDbContext>();
            services.AddTransient<IModelBinder, IocCustomCreationConverter>(); services.AddTransient<RI.Framework.Core.Logging.Contracts.ILoggerExtension, LoggerExtension>();
            services.AddTransient(typeof(IAuditLogger), (p) =>
            {
                var auditLogger = new AuditLogger();
                var dbContext = p.GetService(typeof(DbContext));
                auditLogger.Init(dbContext);
                return auditLogger;
            });
        }
    }
}