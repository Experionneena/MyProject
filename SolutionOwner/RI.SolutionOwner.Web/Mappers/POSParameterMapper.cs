//------------------------------------------------------
// <copyright file="POSParameterMapper.cs" company="RechargeIndia">
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
    /// This class maps between IPOSParameter and POSParameterModel
    /// </summary>
    public class POSParameterMapper : ObjectMapper<POSParameterDto, POSParameterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSParameterMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public POSParameterMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns IPOSParameterCategory entity.</returns>
        public override POSParameterDto ToEntity(POSParameterModel model)
        {
            var entity = CreateEntity();
            entity.Id = model.Id;
            entity.ParameterName = model.ParameterName;
            entity.DisplayOrder = model.DisplayOrder;
            entity.IsActive = model.IsActive;
            entity.POSParameterCategoryId = model.POSParameterCategoryId;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns POSParmeterCategoryModel model.</returns>
        public override POSParameterModel ToObject(POSParameterDto entity)
        {
            var model = new POSParameterModel();
            model.Id = entity.Id;
            model.ParameterName = entity.ParameterName;
            model.DisplayOrder = entity.DisplayOrder;
            model.IsActive = entity.IsActive;
            model.POSParameterCategoryId = entity.POSParameterCategoryId;
            return model;
        }
    }
}