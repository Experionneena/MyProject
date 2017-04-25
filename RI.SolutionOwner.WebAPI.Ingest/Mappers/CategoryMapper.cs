//-------------------------------------------------------------
// <copyright file="CategoryMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------
using System;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    /// <summary>
    /// This class maps ISOCategory to CategoryViewModel and viceversa.
    /// </summary>
    public class CategoryMapper : ObjectMapper<ISOCategory, CategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMapper" /> class.
        /// </summary>
        /// <param name="services">the services.</param>
        public CategoryMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To entity
        /// </summary>
        /// <param name="value">category value</param>
        /// <returns>the category entity</returns>
        public override ISOCategory ToEntity(CategoryViewModel value)
        {
            var categoryEntity = CreateEntity();
            categoryEntity.Id = value.Id;
            categoryEntity.CategoryName = value.CategoryName;
            categoryEntity.DisplayName = value.DisplayName;
            categoryEntity.CategoryDescription = value.CategoryDescription;
            categoryEntity.IconClass = value.IconClass;
            categoryEntity.SortOrder = value.SortOrder;
            categoryEntity.ParentId = value.CategoryId;
            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.EditedDate = DateTime.Now;
            return categoryEntity;
        }

        /// <summary>
        /// from entity
        /// </summary>
        /// <param name="entity">category entity</param>
        /// <returns>category model</returns>
        public override CategoryViewModel ToObject(ISOCategory entity)
        {
            var model = new CategoryViewModel();
            model.Id = entity.Id;
            model.CategoryName = entity.CategoryName;
            model.DisplayName = entity.DisplayName;
            model.CategoryDescription = entity.CategoryDescription;
            model.IconClass = entity.IconClass;
            model.SortOrder = entity.SortOrder;
            model.CategoryId = entity.ParentId;
            model.CreatedDate = DateTime.Now;
            model.EditedDate = DateTime.Now;
            return model;
        }
    }
}