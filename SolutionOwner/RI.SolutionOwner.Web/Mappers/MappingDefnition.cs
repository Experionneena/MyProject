//-----------------------------------------------------------
// <copyright file="MappingDefnition.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------
using System.Linq;
using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Web.References;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// Class MappingDefnition
    /// </summary>
    public class MappingDefnition
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            var domainEntities = ReferencedAssemblies.DomainEntities.GetTypes()
                .Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();

            var businessDtos = ReferencedAssemblies.BusinessDto.GetTypes()
                .Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();
        }
    }
}