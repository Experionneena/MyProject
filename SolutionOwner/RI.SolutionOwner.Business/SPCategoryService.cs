// ---------------------------------------------------------
// <copyright file="SPCategoryService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// Solution Partner Category Service
    /// </summary>
    public class SPCategoryService : ISPCategoryService
    {
        #region private members
        /// <summary>
        /// The category data service
        /// </summary>
        private ISPCategoryDataService categoryDataService;

        /// <summary>
        /// The feature data service
        /// </summary>
        private ISPFeatureDataService featureDataService;

        #endregion
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryService"/> class.
        /// </summary>
        /// <param name="categoryDataService">The category data service.</param>
        /// <param name="featureDataService">The feature data service.</param>
        public SPCategoryService(ISPCategoryDataService categoryDataService, ISPFeatureDataService featureDataService)
        {
            this.categoryDataService = categoryDataService;
            this.featureDataService = featureDataService;
        }
        #endregion
        #region methods
        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>Boolean Value</returns>
        public bool CreateCategory(ISPCategory category)
        {
            return categoryDataService.CreateCategory(category);
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Boolean Value</returns>
        public async Task<bool> DeleteCategory(int categoryId)
        {
            bool result = false;
            result = await categoryDataService.GetCategoryByParentId(categoryId);
            if (result)
            {
                return false;
            }

            result = featureDataService.GetFeatureForCategory(categoryId);
            if (result)
            {
                return false;
            }

            var status = categoryDataService.DeleteCategory(categoryId);
            return status;
        }

        /// <summary>
        /// Get AllCategories
        /// </summary>
        /// <returns>ISPCategory Object</returns>
        public async Task<IEnumerable<ISPCategory>> GetAllCategories()
        {
            return await categoryDataService.GetAllCategories();
        }

        /// <summary>
        /// Get CategoryById
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>ISPCategory Object</returns>
        public async Task<ISPCategory> GetCategoryById(int categoryId)
        {
            return await categoryDataService.GetCategoryById(categoryId);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>Boolean Value</returns>
        public async Task<bool> UpdateCategory(ISPCategory category)
        {
            var success = await categoryDataService.UpdateCategory(category);
            return success;
        }
        #endregion
    }
}
