// ---------------------------------------------------------
// <copyright file="SPFeatureMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// Solution Partner Feature Mapper
    /// </summary>
    public class SPFeatureMapper : ObjectMapper<SPFeatureDto, Web.Models.SPFeatureViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPFeatureMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public SPFeatureMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SPFeatureDto Object</returns>
        public override SPFeatureDto ToEntity(Web.Models.SPFeatureViewModel value)
        {
            var featureEntity = new SPFeatureDto();
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
            featureEntity.HierarchyId = value.HierarchyId;
            ////featureEntity.EditedDate = DateTime.UtcNow;
            return featureEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns>SPFeatureViewModel Object</returns>
        public override SPFeatureViewModel ToObject(SPFeatureDto featureEntity)
        {
            var model = new SPFeatureViewModel();
            model.Id = featureEntity.Id;
            model.Name = featureEntity.Name;
            model.DisplayName = featureEntity.DisplayName;
            model.IconClass = featureEntity.IconClass;
            model.ProgramLink = featureEntity.ProgramLink;
            model.IsActive = featureEntity.IsActive;
            model.CategoryId = featureEntity.CategoryId;
            model.HierarchyId = featureEntity.HierarchyId;
            model.SortOrder = featureEntity.SortOrder;
            model.ParentCatId = featureEntity.CategoryId;
            model.CreatedDate = featureEntity.CreatedDate ?? DateTime.MinValue;
            ////model.EditedDate = featureEntity.EditedDate;
            return model;
        }
    }
}