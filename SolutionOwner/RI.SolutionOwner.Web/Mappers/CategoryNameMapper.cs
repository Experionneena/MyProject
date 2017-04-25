//-----------------------------------------------------------
// <copyright file="CategoryNameMapper.cs" company="RechargeIndia">
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
    /// Class CategoryNameMapper
    /// </summary>
    public class CategoryNameMapper : ObjectMapper<SOCategoryDto, EditCategoryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryNameMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public CategoryNameMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Interface ISOCategory</returns>
        public override SOCategoryDto ToEntity(EditCategoryModel value)
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
        /// <returns>Model EditCategoryModel</returns>
        public override EditCategoryModel ToObject(SOCategoryDto entity)
        {
            var model = new EditCategoryModel();
            model.Id = entity.Id;
            model.DisplayName = entity.DisplayName;
            model.ParentId = entity.ParentId;
            return model;
        }
    }
}