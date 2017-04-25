//-------------------------------------------------------------
// <copyright file="CategoryService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Business
{
    /// <summary>
    /// class CategoryService
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region private members

        /// <summary>
        /// private member categoryDataService
        /// </summary>
        private ICategoryDataService categoryDataService;

        /// <summary>
        /// private member featureDataService
        /// </summary>
        private IFeatureDataService featureDataService;
        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="categoryDataService">categoryDataService instance</param>
        /// <param name="featureDataService">featureDataService instance</param>
        public CategoryService(ICategoryDataService categoryDataService, IFeatureDataService featureDataService)
        {
            this.categoryDataService = categoryDataService;
            this.featureDataService = featureDataService;
        }
        #endregion

        #region methods

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category">the category</param>
        /// <returns>boolean value</returns>
        public bool CreateCategory(ISOCategory category)
        {
            return this.categoryDataService.CreateCategory(category);
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="categoryId">the category identifier</param>
        /// <returns>boolean value</returns>
        public async Task<bool> DeleteCategory(int categoryId)
        {
            var result = false;
            result = await this.categoryDataService.GetCategoryByParentId(categoryId);
            if (!result)
            {
                result = this.featureDataService.GetFeatureForCategory(categoryId);
            }

            if (!result)
            {
                return this.categoryDataService.DeleteCategory(categoryId);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>list of categories</returns>
        public async Task<IEnumerable<ISOCategory>> GetAllCategories()
        {
            return await this.categoryDataService.GetAllCategories();
        }

        /// <summary>
        /// Get CategoryBy Id
        /// </summary>
        /// <param name="categoryId">category identifier</param>
        /// <returns>category entity</returns>
        public async Task<ISOCategory> GetCategoryById(int categoryId)
        {
            return await this.categoryDataService.GetCategoryById(categoryId);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category">the category</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdateCategory(ISOCategory category)
        {
            var updationStatus = await this.categoryDataService.UpdateCategory(category);
            return updationStatus;
        }
        #endregion
    }
}
