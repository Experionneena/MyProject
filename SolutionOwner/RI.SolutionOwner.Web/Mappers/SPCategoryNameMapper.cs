// ---------------------------------------------------------
// <copyright file="SPCategoryNameMapper.cs" company="RechargeIndia">
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
    public class SPCategoryNameMapper : ObjectMapper<SPCategoryDto, SPEditCategoryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryNameMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public SPCategoryNameMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SPCategoryDto Object</returns>
        public override SPCategoryDto ToEntity(SPEditCategoryModel value)
        {
            var categoryEntity = CreateEntity();
            categoryEntity.Id = value.Id;
            categoryEntity.DisplayName = value.DisplayName;
            categoryEntity.ParentId = value.ParentId;
            return categoryEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SPEditCategoryModel Object</returns>
        public override SPEditCategoryModel ToObject(SPCategoryDto entity)
        {
            var model = new SPEditCategoryModel();
            model.Id = entity.Id;
            model.DisplayName = entity.DisplayName;
            model.ParentId = entity.ParentId;
            return model;
        }      
    }
}