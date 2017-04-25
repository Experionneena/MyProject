//------------------------------------------------------------------
// <copyright file="RoleFeaturePermissionMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------------------

using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// This class maps ISORolePermission to RoleFeaturePermissionViewModel and viceversa.
    /// </summary>
    public class RoleFeaturePermissionMapper : ObjectMapper<SORolePermissionDto, RoleFeaturePermissionViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFeaturePermissionMapper" /> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public RoleFeaturePermissionMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns ISORolePermission entity</returns>
        public override SORolePermissionDto ToEntity(RoleFeaturePermissionViewModel value)
        {
            var entity = CreateEntity();

            entity.Id = value.Id;
            entity.RoleId = value.RoleId;
            entity.FeatureId = value.FeatureId;
            entity.CreatePermission = value.CreatePermission;
            entity.UpdatePermission = value.UpdatePermission;
            entity.ReadPermission = value.ReadPermission;
            entity.DeAvtivatePermission = value.ActivateOrDeactivatePermission;
            entity.DeletePermission = value.DeletePermission;
            entity.ApprovePermission = value.ApprovePermission;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns RoleFeaturePermissionViewModel</returns>
        public override RoleFeaturePermissionViewModel ToObject(SORolePermissionDto entity)
        {
            var value = new RoleFeaturePermissionViewModel();

            value.Id = entity.Id;
            value.RoleId = entity.RoleId;
            value.FeatureId = entity.FeatureId;
            value.CreatePermission = entity.CreatePermission;
            value.UpdatePermission = entity.UpdatePermission;
            value.ReadPermission = entity.ReadPermission;
            value.DeletePermission = entity.DeletePermission;
            value.ActivateOrDeactivatePermission = entity.DeAvtivatePermission;
            value.ApprovePermission = entity.ApprovePermission;
            value.FeatureName = string.Empty;
            return value;
        }
    }
}