//---------------------------------------------------------
// <copyright file="SPProductGroupService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// The Solution partner business service.
    /// </summary>
    public class SPProductGroupService : ISPProductGroupService
    {
        #region Private Members

        /// <summary>
        /// The Solution partner Product group service
        /// </summary>
        private ISPProductGroupDataService productGroupDataService = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPProductGroupService" /> class.
        /// </summary>
        /// <param name="productGroupDataService">The product group data service.</param>
        public SPProductGroupService(
            ISPProductGroupDataService productGroupDataService)
        {
            this.productGroupDataService = productGroupDataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets collection of Product group.
        /// </summary>
        /// <returns>Collection of Product group</returns>
        public Task<IEnumerable<ISPProductGroup>> Get()
        {
            return productGroupDataService.Get();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The production group instance.</returns>
        public Task<ISPProductGroup> Get(int productGroupId)
        {
            return productGroupDataService.Get(productGroupId);
        }

        /// <summary>
        /// Creates the specified product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Creation status.</returns>
        public bool Create(ISPProductGroup productGroup)
        {
            return productGroupDataService.Create(productGroup);
        }

        /// <summary>
        /// Modifies the specified product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>The modification status.</returns>
        public bool Modify(ISPProductGroup productGroup)
        {
            return productGroupDataService.Modify(productGroup);
        }

        /// <summary>
        /// Changes the active status.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <param name="activeStatus">if set to <c>true</c> [active status].</param>
        /// <returns>
        /// Status modifying status.
        /// </returns>
        public Task<bool> ChangeActiveStatus(int productGroupId, int activeStatus)
        {
            bool activationStatus = (activeStatus == 1) ? true : false;
            return productGroupDataService.ChangeActiveStatus(productGroupId, activationStatus);
        }

        /// <summary>
        /// Deletes the product group.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The deletion status.</returns>
        public Task<bool> DeleteProductGroup(int productGroupId)
        {
            return productGroupDataService.DeleteProductGroup(productGroupId);
        }

        /// <summary>
        /// Gets the service providers.
        /// </summary>
        /// <returns>
        /// Collection of SP
        /// </returns>
        public Task<IEnumerable<ISPServiceProvider>> GetServiceProviders()
        {
            return productGroupDataService.GetServiceProviders();
        }

        #endregion
    }
}
