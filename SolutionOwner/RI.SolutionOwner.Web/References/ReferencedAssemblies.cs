//---------------------------------------------------------
// <copyright file="ReferencedAssemblies.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------
using System.Reflection;

namespace RI.SolutionOwner.Web.References
{
    /// <summary>
    /// Class ReferencedAssemblies
    /// </summary>
    public static class ReferencedAssemblies
    {
        /// <summary>
        /// Gets the business dto.
        /// </summary>
        /// <value>
        /// The business dto.
        /// </value>
        public static Assembly BusinessDto
        {
            get
            {
                return Assembly.Load("RI.SolutionOwner.Business");
            }
        }

        /// <summary>
        /// Gets the data services.
        /// </summary>
        /// <value>
        /// The data services.
        /// </value>
        public static Assembly DataServices
        {
            get
            {
                return Assembly.Load("RI.SolutionOwner.Data.Services");
            }
        }

        /// <summary>
        /// Gets the domain entities.
        /// </summary>
        /// <value>
        /// The domain entities.
        /// </value>
        public static Assembly DomainEntities
        {
            get
            {
                return Assembly.Load("RI.SolutionOwner.Data");
            }
        }
    }
}