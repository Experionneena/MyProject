// ---------------------------------------------------------
// <copyright file="SPCategoryDataService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.Framework.Core.Data;
using RI.Framework.Core.Data.Services;
using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Data.Services.Contracts;

namespace RI.SolutionOwner.Data.Services
{
    /// <summary>
    /// Solution Partner Category Data Service
    /// </summary>
    public class SPCategoryDataService : BaseDataService, ISPCategoryDataService
    {
        #region private members
        /// <summary>
        /// The partner category
        /// </summary>
        private IRepository<ISPCategory> partnerCategory = null;

        #endregion
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryDataService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public SPCategoryDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            partnerCategory = UnitOfWork.Repository<ISPCategory>();
        }
        #endregion
        #region Methods

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Boolean Value</returns>
        public bool CreateCategory(ISPCategory category)
        {
            if (category.ParentId == null)
            {
                var exists = partnerCategory.Entities
                .Where(x => x.CategoryName == category.CategoryName || x.DisplayName == category.DisplayName)
                .FirstOrDefault();
                if (exists != null)
                {
                    return false;
                }

                var newFeature = partnerCategory.Add(category);
                UnitOfWork.Commit();
                return true;
            }

            if (category.ParentId != null)
            {
                var categoryExistancy = partnerCategory.Entities.Where(x => x.ParentId == category.ParentId && (x.CategoryName == category.CategoryName || x.DisplayName == category.DisplayName)).FirstOrDefault();
                if (categoryExistancy == null)
                {
                    var newFeature = partnerCategory.Add(category);
                    UnitOfWork.Commit();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="categoryId">The category Identifier.</param>
        /// <returns>Boolean Value.</returns>
        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var item = Task.Run(async () =>
                 {
                     return await partnerCategory.GetByIdAsync(categoryId);
                 });
                var category = item.Result;
                partnerCategory.Delete(category);
                var deleteResponse = UnitOfWork.Commit();
                return deleteResponse == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get AllCategories
        /// </summary>
        /// <returns>ISPCategory Object.</returns>
        public async Task<IEnumerable<ISPCategory>> GetAllCategories()
        {
            return await partnerCategory.GetAllAsync();
        }

        /// <summary>
        /// Get A Category Using Identifier
        /// </summary>
        /// <param name="categoryId">The category Identifier.</param>
        /// <returns>ISPCategory Object.</returns>
        public async Task<ISPCategory> GetCategoryById(int categoryId)
        {
            var categories = await partnerCategory.GetByIdAsync(categoryId);
            return categories;
        }

        /// <summary>
        /// Gets the category by parent identifier.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>Boolean value</returns>
        public async Task<bool> GetCategoryByParentId(int parentId)
        {
            var categoryList = new List<ISPCategory>(await partnerCategory.GetAllAsync());
            if (categoryList.Count > 0)
            {
                var categories = categoryList.Where(x => x.ParentId == parentId).ToList();
                return categories.Count > 0 ? true : false;
            }

            return false;
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category">The category.s</param>
        /// <returns>boolean Value.</returns>
        public async Task<bool> UpdateCategory(ISPCategory category)
        {
            try
            {

                bool categoryExist = false;

                var categoryList = new List<ISPCategory>(await this.partnerCategory.GetAllAsync());
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

                if (categoryExist)
                {
                    return false;
                }



                var categoryEntity = await partnerCategory.GetByIdAsync(category.Id);
                categoryEntity.Id = category.Id;
                categoryEntity.ParentId = category.ParentId;
                categoryEntity.SortOrder = category.SortOrder;
                categoryEntity.EditedDate = category.EditedDate;
                categoryEntity.DisplayName = category.DisplayName;
                categoryEntity.CreatedDate = category.CreatedDate;
                categoryEntity.CategoryName = category.CategoryName;
                categoryEntity.CategoryDescription = category.CategoryDescription;
                categoryEntity.IconClass = category.IconClass;
                partnerCategory.Update(categoryEntity);
                var updatedcategory = UnitOfWork.Commit();
                return updatedcategory == 0 ? true : false;
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
