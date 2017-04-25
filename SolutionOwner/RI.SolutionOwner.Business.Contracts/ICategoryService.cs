// ---------------------------------------------------------
// <copyright file="ICategoryService.cs" company="RechargeIndia">
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
    /// interface ICategoryService
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// create new category
        /// </summary>
        /// <param name="category">category object</param>
        /// <returns>boolean value</returns>
        bool CreateCategory(ISOCategory category);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category">category object</param>
        /// <returns>boolean value</returns>
        Task<bool> UpdateCategory(ISOCategory category);

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="categoryId">category Id</param>
        /// <returns>boolean value</returns>
        Task<bool> DeleteCategory(int categoryId);

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>category list</returns>
        Task<IEnumerable<ISOCategory>> GetAllCategories();

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="categoryId">category id</param>
        /// <returns>category object</returns>
        Task<ISOCategory> GetCategoryById(int categoryId);
    }
}
