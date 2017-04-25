//-----------------------------------------------------------
// <copyright file="CategoryMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------
using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// Class CategoryMapper
    /// </summary>
    public class CategoryMapper : ObjectMapper<SOCategoryDto, CategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public CategoryMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Interface ISOCategory</returns>
        public override SOCategoryDto ToEntity(CategoryViewModel value)
        {
            var categoryEntity = CreateEntity();
            categoryEntity.Id = value.Id;
            categoryEntity.CategoryName = value.CategoryName;
            categoryEntity.DisplayName = value.DisplayName;
            categoryEntity.CategoryDescription = value.CategoryDescription;
            categoryEntity.IconClass = value.IconClass;
            categoryEntity.SortOrder = value.SortOrder;
            categoryEntity.ParentId = value.ParentId;
            return categoryEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Model CategoryViewModel</returns>
        public override CategoryViewModel ToObject(SOCategoryDto entity)
        {
            var model = new CategoryViewModel();
            model.Id = entity.Id;
            model.CategoryName = entity.CategoryName;
            model.DisplayName = entity.DisplayName;
            model.CategoryDescription = entity.CategoryDescription;
            model.IconClass = entity.IconClass;
            model.SortOrder = entity.SortOrder;
            model.ParentId = entity.ParentId;
            return model;
        }
    }
}