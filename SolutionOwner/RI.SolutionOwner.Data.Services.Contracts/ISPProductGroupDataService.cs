//---------------------------------------------------------
// <copyright file="ISPProductGroupDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// The Solution partner Product group data service abstraction.
    /// </summary>
    public interface ISPProductGroupDataService : IDataService
    {
        /// <summary>
        /// Gets collection of Product group.
        /// </summary>
        /// <returns>Collection of Product group</returns>
        Task<IEnumerable<ISPProductGroup>> Get();

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The production group instance.</returns>
        Task<ISPProductGroup> Get(int productGroupId);

        /// <summary>
        /// Creates the specified product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Creation status.</returns>
        bool Create(ISPProductGroup productGroup);

        /// <summary>
        /// Modifies the specified product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>The modification status.</returns>
        bool Modify(ISPProductGroup productGroup);

        /// <summary>
        /// Changes the active status.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <param name="activeStatus">if set to <c>true</c> [active status].</param>
        /// <returns>
        /// Status modifying status.
        /// </returns>
        Task<bool> ChangeActiveStatus(int productGroupId, bool activeStatus);
        
        /// <summary>
        /// Deletes the product group.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The deletion status.</returns>
        Task<bool> DeleteProductGroup(int productGroupId);

        /// <summary>
        /// Gets the service providers.
        /// </summary>
        /// <returns>The Collection.</returns>
        Task<IEnumerable<ISPServiceProvider>> GetServiceProviders();
    }
}
