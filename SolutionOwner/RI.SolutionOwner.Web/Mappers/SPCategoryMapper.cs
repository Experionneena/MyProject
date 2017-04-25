// ---------------------------------------------------------
// <copyright file="SPCategoryMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// Solution Partner Category Mapper
    /// </summary>
    public class SPCategoryMapper : ObjectMapper<SPCategoryDto, SPCategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public SPCategoryMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SPCategoryDto Object</returns>
        public override SPCategoryDto ToEntity(SPCategoryViewModel value)
        {
            var categoryEntity = new SPCategoryDto();
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
        /// <returns>SPCategoryViewModel Object</returns>
        public override SPCategoryViewModel ToObject(SPCategoryDto entity)
        {
            var model = new SPCategoryViewModel();
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