//-------------------------------------------------------------
// <copyright file="ICategoryDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using RI.Framework.Core.Data.Services;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Services.Contracts
{
    /// <summary>
    /// interface ICategoryDataService
    /// </summary>
    public interface ICategoryDataService : IDataService
    {
        /// <summary>
        /// create a category
        /// </summary>
        /// <param name="category">the category</param>
        /// <returns>boolean value</returns>
        bool CreateCategory(ISOCategory category);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category">the category</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdateCategory(ISOCategory category);

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="categoryId">category identifier</param>
        /// <returns>boolean value</returns>
        bool DeleteCategory(int categoryId);

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>list of categories</returns>
        Task<IEnumerable<ISOCategory>> GetAllCategories();

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="categoryId">category identifier</param>
        /// <returns>the category</returns>
        Task<ISOCategory> GetCategoryById(int categoryId);

        /// <summary>
        /// Get Category By Parent Id
        /// </summary>
        /// <param name="categoryId">category identifier</param>
        /// <returns>the category</returns>
        Task<bool> GetCategoryByParentId(int categoryId);
    }
}
