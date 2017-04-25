//------------------------------------------------------
// <copyright file="POSParameterCategoryMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//--------------------------------------------------------

using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// This class maps IPOSParameterCategory to POSParmeterCategoryModel and viceversa.
    /// </summary>
    public class POSParameterCategoryMapper : ObjectMapper<POSParameterCategoryDto, POSParmeterCategoryModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSParameterCategoryMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public POSParameterCategoryMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns IPOSParameterCategory entity.</returns>
        public override POSParameterCategoryDto ToEntity(POSParmeterCategoryModel model)
        {
            var entity = CreateEntity();
            entity.Id = model.Id;
            entity.ParameterCategory = model.ParameterCategory;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns POSParmeterCategoryModel model.</returns>
        public override POSParmeterCategoryModel ToObject(POSParameterCategoryDto entity)
        {
            var model = new POSParmeterCategoryModel();
            model.Id = entity.Id;
            model.ParameterCategory = entity.ParameterCategory;
            return model;
        }
    }
}