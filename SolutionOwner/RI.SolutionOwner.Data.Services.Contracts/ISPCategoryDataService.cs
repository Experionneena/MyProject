// ---------------------------------------------------------
// <copyright file="ISPCategoryDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// Solution Partner Category Data Service Interface
    /// </summary>
    public interface ISPCategoryDataService : IDataService
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
        bool DeleteCategory(int categoryId);

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>ISPCategory object</returns>
        Task<IEnumerable<ISPCategory>> GetAllCategories();

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>ISPCategory object</returns>
        Task<ISPCategory> GetCategoryById(int categoryId);

        /// <summary>
        /// Gets the category by Parent identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>ISPCategory object</returns>
        Task<bool> GetCategoryByParentId(int categoryId);
    }
}
