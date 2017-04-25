//---------------------------------------------------------------
// <copyright file="UnityConfig.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.EntityFramework;
using RI.SolutionOwner.Business;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Entities;
using RI.SolutionOwner.Data.Services;
using RI.SolutionOwner.Data.Services.Contracts;
using Unity.WebApi;

namespace RI.SolutionOwner.WebAPI
{
    /// <summary>
    /// This class initialize the Unity container and register the DependencyResolver with the framework
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers the components.
        /// </summary>
        public static void RegisterComponents()
        {
            //////var container = new UnityContainer();

            //// register all your components with the container here
            //// it is NOT necessary to register your controllers

            ////GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            ////GlobalConfiguration.Configuration.DependencyResolver = new CustomDependencyResolver();

            ////GlobalConfiguration.Configuration.DependencyResolver = new CustomDependencyResolver();

        }
    }
}