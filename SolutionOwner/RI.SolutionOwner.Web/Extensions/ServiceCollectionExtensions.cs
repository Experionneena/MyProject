﻿//<auto-generated/>
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
using Microsoft.Framework.DependencyInjection;
using RI.Framework.Audit.Abstraction;
using RI.Framework.Audit.EntityFramework;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.EntityFramework;
using RI.Framework.Core.Logging.Extensions;
using RI.SolutionOwner.Data;

namespace RI.SolutionOwner.Web.Extensions
{
    /// <summary>
    /// This class maps the interfaces to the implementations in the Web
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
                .Where(t => t.GetTypeInfo()
                .BaseType.Name == "ObjectMapper`2")
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

        // Exception occurs when there may be wrong implementation 
        // or not inherting the interface or wrong naming (mismatch in naming between interface and its implementation)

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

        ///// <summary>
        ///// Adds the manual registration.
        ///// </summary>
        ///// <param name="services">The services.</param>
        public static void AddManualRegistration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DbContext, SolutionOwnerDbContext>();
            services.AddTransient<RI.Framework.Core.Logging.Contracts.ILoggerExtension, LoggerExtension>();
            services.AddScoped(typeof(IAuditLogger), (p) =>
            {
                var auditLogger = new AuditLogger();
                var dbContext = p.GetService(typeof(DbContext));
                auditLogger.Init(dbContext);
                return auditLogger;
            });
        }
    }
}