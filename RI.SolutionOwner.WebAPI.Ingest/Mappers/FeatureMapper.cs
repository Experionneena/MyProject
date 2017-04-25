//---------------------------------------------------------
// <copyright file="FeatureMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    /// <summary>
    /// The feature entity mapper.
    /// </summary>
    public class FeatureMapper : ObjectMapper<ISOFeature, FeatureViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public FeatureMapper(IServiceProvider provider) : base(provider)
        { }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public override ISOFeature ToEntity(FeatureViewModel value)
        {
            var featureEntity = CreateEntity();
            featureEntity.Id = value.Id;
            featureEntity.Name = value.Name;
            featureEntity.ProgramLink = value.ProgramLink;
            featureEntity.IsActive = value.IsActive;
            ////featureEntity.EditedDate = DateTime.UtcNow;
            return featureEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="featureEntity">The feature entity.</param>
        /// <returns></returns>
        public override FeatureViewModel ToObject(ISOFeature featureEntity)
        {
            var model = new FeatureViewModel();
            model.Id = featureEntity.Id;
            model.Name = featureEntity.Name;
            model.ProgramLink = featureEntity.ProgramLink;
            model.IsActive = featureEntity.IsActive;
            ////model.EditedDate = featureEntity.EditedDate;
            return model;
        }
    }
}