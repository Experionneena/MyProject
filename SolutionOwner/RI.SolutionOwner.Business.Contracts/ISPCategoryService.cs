// ---------------------------------------------------------
// <copyright file="ISPCategoryService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// Solution Partner Category Service
    /// </summary>
    public interface ISPCategoryService
    {
        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Boolean Value</returns>
        bool CreateCategory(ISPCategory category);

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Boolean Value</returns>
        Task<bool> UpdateCategory(ISPCategory category);

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>Boolean Value</returns>
        Task<bool> DeleteCategory(int categoryId);

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>ISPCategory object</returns>
        Task<IEnumerable<ISPCategory>> GetAllCategories();

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>ISPCategory Object</returns>
        Task<ISPCategory> GetCategoryById(int categoryId);
    }
}
