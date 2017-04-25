//----------------------------------------------------------
// <copyright file="HierarchyMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------
using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// Hierarchy Mapper
    /// </summary>
    public class HierarchyMapper : ObjectMapper<HierarchyDto, HierarchyViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchyMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public HierarchyMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Hierarchy Entity</returns>
        public override HierarchyDto ToEntity(Web.Models.HierarchyViewModel value)
        {
            var hierarchyEntity = CreateEntity();
            hierarchyEntity.Id = value.Id;
            hierarchyEntity.Name = value.Name;
            hierarchyEntity.CreatedDate = value.CreatedDate;
            ////featureEntity.EditedDate = DateTime.UtcNow;
            return hierarchyEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns>Hierarchy View Model</returns>
        public override HierarchyViewModel ToObject(HierarchyDto featureEntity)
        {
            var model = new HierarchyViewModel();
            model.Id = featureEntity.Id;
            model.Name = featureEntity.Name;
            model.CreatedDate = featureEntity.CreatedDate ?? DateTime.MinValue;
            ////model.EditedDate = featureEntity.EditedDate;
            return model;
        }
    }
}