//-------------------------------------------------------------
// <copyright file="CategoryDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------
using System;
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
    /// class CategoryDataService
    /// </summary>
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        #region private members
        /// <summary>
        /// private member category
        /// </summary>
        private IRepository<ISOCategory> category;
        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public CategoryDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.category = UnitOfWork.Repository<ISOCategory>();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>boolean value</returns>
        public bool CreateCategory(ISOCategory category)
        {
            if (category.ParentId == null)
            {
                var categoryExistancy = this.category.Entities.Where(x => x.ParentId == null && (x.CategoryName == category.CategoryName || x.DisplayName == category.DisplayName)).FirstOrDefault();
                if (categoryExistancy == null)
                {
                    var newFeature = this.category.Add(category);
                    UnitOfWork.Commit();
                    return true;
                }
            }

            if (category.ParentId != null)
            {
                var categoryExistancy = this.category.Entities.Where(x => x.ParentId == category.ParentId && (x.CategoryName == category.CategoryName || x.DisplayName == category.DisplayName)).FirstOrDefault();
                if (categoryExistancy == null)
                {
                    var newFeature = this.category.Add(category);
                    UnitOfWork.Commit();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="categoryId">category Identifier</param>
        /// <returns>boolean value</returns>
        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var item = Task.Run(async () =>
                {
                    return await this.category.GetByIdAsync(categoryId);
                });
                var category = item.Result;
                this.category.Delete(category);
                var deleteResponse = UnitOfWork.Commit();
                return deleteResponse == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns>List of categories</returns>
        public async Task<IEnumerable<ISOCategory>> GetAllCategories()
        {
            return await this.category.GetAllAsync();
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="categoryId">category idenitifier</param>
        /// <returns>ISOCategory entity</returns>
        public async Task<ISOCategory> GetCategoryById(int categoryId)
        {
            var categories = await this.category.GetByIdAsync(categoryId);
            return categories;
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>boolean value</returns>
        public async Task<bool> UpdateCategory(ISOCategory category)
        {
            try
            {
                bool categoryExist = false;

                var categoryList = new List<ISOCategory>(await this.category.GetAllAsync());
                if (categoryList.Count() > 1)
                {
                    var item = categoryList.FirstOrDefault(x => x.Id == category.Id);
                    categoryList.Remove(item);
                    if (category.ParentId != null)
                    {
                        categoryExist = categoryList.Where(x => x.ParentId == category.ParentId && (x.CategoryName == category.CategoryName || x.DisplayName == category.DisplayName)).Any();
                    }

                    if (category.ParentId == null)
                    {
                        categoryExist = categoryList.Where(x => x.ParentId == null && (x.CategoryName == category.CategoryName || x.DisplayName == category.DisplayName)).Any();
                    }
                }

                if (!categoryExist)
                {
                    var categoryEntity = await this.category.GetByIdAsync(category.Id);
                    categoryEntity.Id = category.Id;
                    categoryEntity.ParentId = category.ParentId;
                    categoryEntity.SortOrder = category.SortOrder;
                    categoryEntity.EditedDate = category.EditedDate;
                    categoryEntity.DisplayName = category.DisplayName;
                    categoryEntity.CreatedDate = category.CreatedDate;
                    categoryEntity.CategoryName = category.CategoryName;
                    categoryEntity.CategoryDescription = category.CategoryDescription;
                    categoryEntity.IconClass = category.IconClass;
                    this.category.Update(categoryEntity);
                    var updatedcategory = UnitOfWork.Commit();
                    return updatedcategory == 0 ? true : false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the category by parent identifier.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>return ISOCategory Entity.</returns>
        public async Task<bool> GetCategoryByParentId(int parentId)
        {
            var categoryList = new List<ISOCategory>(await this.category.GetAllAsync());
            if (categoryList.Count > 0)
            {
                var categories = categoryList.Where(x => x.ParentId == parentId).ToList();
                return categories.Count > 0 ? true : false;
            }

            return false;
        }

        #endregion
    }
}