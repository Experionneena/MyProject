//---------------------------------------------------------
// <copyright file="ISPProductGroupService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// The Solution partner Product group service abstraction.
    /// </summary>
    public interface ISPProductGroupService
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
        /// <returns>The Product group.</returns>
        bool Modify(ISPProductGroup productGroup);

        /// <summary>
        /// Changes the active status.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <param name="activeStatus">if set to <c>true</c> [active status].</param>
        /// <returns>
        /// Status modifying status.
        /// </returns>
        Task<bool> ChangeActiveStatus(int productGroupId, int activeStatus);

        /// <summary>
        /// Deletes the product group.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The deletion status.</returns>
        Task<bool> DeleteProductGroup(int productGroupId);

        /// <summary>
        /// Gets the service providers.
        /// </summary>
        /// <returns>Collection of SP</returns>
        Task<IEnumerable<ISPServiceProvider>> GetServiceProviders();
    }
}
