//-----------------------------------------------------------
// <copyright file="FeatureMapper.cs" company="RechargeIndia">
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
    /// Class FeatureMapper
    /// </summary>
    public class FeatureMapper : ObjectMapper<SOFeatureDto, Web.Models.FeatureViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public FeatureMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Interface ISOFeature</returns>
        public override SOFeatureDto ToEntity(FeatureViewModel value)
        {
            var featureEntity = CreateEntity();
            featureEntity.Id = value.Id;
            featureEntity.Name = value.Name;
            featureEntity.ProgramLink = value.ProgramLink;
            featureEntity.IsActive = value.IsActive;
            featureEntity.CategoryId = value.CategoryId;
            featureEntity.IconClass = value.IconClass;
            featureEntity.DisplayName = value.DisplayName;
            featureEntity.SortOrder = value.SortOrder;
            featureEntity.CategoryId = value.CategoryId;
            featureEntity.CreatedDate = value.CreatedDate;
            ////featureEntity.EditedDate = DateTime.UtcNow;
            return featureEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns>Model FeatureViewModel</returns>
        public override FeatureViewModel ToObject(SOFeatureDto featureEntity)
        {
            var model = new FeatureViewModel();
            model.Id = featureEntity.Id;
            model.Name = featureEntity.Name;
            model.DisplayName = featureEntity.DisplayName;
            model.IconClass = featureEntity.IconClass;
            model.ProgramLink = featureEntity.ProgramLink;
            model.IsActive = featureEntity.IsActive;
            model.CategoryId = featureEntity.CategoryId;
            model.SortOrder = featureEntity.SortOrder;
            model.ParentCatId = featureEntity.CategoryId;
            model.CreatedDate = featureEntity.CreatedDate ?? DateTime.MinValue;
            ////model.EditedDate = featureEntity.EditedDate;
            return model;
        }
    }
}