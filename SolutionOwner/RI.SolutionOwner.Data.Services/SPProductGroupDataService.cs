//---------------------------------------------------------
// <copyright file="SPProductGroupDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// The Solution partner Product group data service.
    /// </summary>
    public class SPProductGroupDataService : BaseDataService, ISPProductGroupDataService
    {
        #region Private Members

        /// <summary>
        /// The product group repository.
        /// </summary>
        private IRepository<ISPProductGroup> productGroups = null;

        /// <summary>
        /// The service providers.
        /// </summary>
        private IRepository<ISPServiceProvider> serviceProviders = null; ////UNDO: while implement Service provider

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SPProductGroupDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPProductGroupDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            productGroups = UnitOfWork.Repository<ISPProductGroup>();
            serviceProviders = UnitOfWork.Repository<ISPServiceProvider>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets collection of Product group.
        /// </summary>
        /// <returns>Collection of Product group</returns>
        public async Task<IEnumerable<ISPProductGroup>> Get()
        {
            return await productGroups.GetAllAsync();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The production group instance.</returns>
        public async Task<ISPProductGroup> Get(int productGroupId)
        {
            return await productGroups.GetByIdAsync(productGroupId);
        }

        /// <summary>
        /// Creates the specified product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>Creation status.</returns>
        public bool Create(ISPProductGroup productGroup)
        {
            var existancyStatus = productGroups.Entities
                .Any(x => x.ServiceProviderId == productGroup.ServiceProviderId
                    && x.Name == productGroup.Name);

            if (!existancyStatus)
            {
                var newProductGroup = productGroups.Add(productGroup);
                var creationStatus = UnitOfWork.Commit();
                return (creationStatus == 0) ? true : false;
            }

            return false;
        }

        /// <summary>
        /// Modifies the specified product group.
        /// </summary>
        /// <param name="productGroup">The product group.</param>
        /// <returns>The modification status.</returns>
        public bool Modify(ISPProductGroup productGroup)
        {
            var existancyStatus = productGroups.Entities
                .Any(x => x.ServiceProviderId == productGroup.ServiceProviderId
                    && x.Name == productGroup.Name
                    && x.Id != productGroup.Id);

            if (!existancyStatus)
            {
                productGroups.Update(productGroup);
                var updateStatus = UnitOfWork.Commit();
                return (updateStatus == 0) ? true : false;
            }

            return false;
        }

        /// <summary>
        /// Changes the active status.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <param name="activeStatus">if set to <c>true</c> [flag].</param>
        /// <returns>
        /// Status modifying status.
        /// </returns>
        public async Task<bool> ChangeActiveStatus(int productGroupId, bool activeStatus)
        {
            var productGroup = await productGroups.GetByIdAsync(productGroupId);

            productGroup.ActiveStatus = activeStatus;
            productGroups.Update(productGroup);
            var updateStatus = UnitOfWork.Commit();
            return (updateStatus == 0) ? true : false;
        }

        /// <summary>
        /// Deletes the product group.
        /// </summary>
        /// <param name="productGroupId">The product group identifier.</param>
        /// <returns>The deletion status.</returns>
        public async Task<bool> DeleteProductGroup(int productGroupId)
        {
            var productGroup = await productGroups.GetByIdAsync(productGroupId);
            
            productGroups.Delete(productGroup);
            var updateStatus = UnitOfWork.Commit();
            return (updateStatus == 0) ? true : false;
        }

        /// <summary>
        /// Gets the service providers.
        /// </summary>
        /// <returns>
        /// The Collection.
        /// </returns>
        public Task<IEnumerable<ISPServiceProvider>> GetServiceProviders()
        {
            return serviceProviders.GetAllAsync();
        }
        
        #endregion
    }
}
