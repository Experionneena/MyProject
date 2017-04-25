//------------------------------------------------------
// <copyright file="RoleMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// This class maps ISORole to RoleViewModel and viceversa.
    /// </summary>
    public class RoleMapper : ObjectMapper<SORoleDto, RoleViewModel>
    {
        /// <summary>
        /// The _permission mapper
        /// </summary>
        private ObjectMapper<SORolePermissionDto, RoleFeaturePermissionViewModel> permissionMapper = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMapper" /> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="permissionMapper">The permission mapper.</param>
        public RoleMapper(
            IServiceProvider provider, ObjectMapper<SORolePermissionDto, RoleFeaturePermissionViewModel> permissionMapper) : base(provider)
        {
            this.permissionMapper = permissionMapper;
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns ISORole entity</returns>
        public override SORoleDto ToEntity(RoleViewModel value)
        {
            var roleEntity = CreateEntity();
            roleEntity.Id = value.Id;
            roleEntity.RoleName = value.RoleName;
            roleEntity.Description = value.Description;
            roleEntity.ActiveStatus = value.IsActive;
            roleEntity.FeatureId = value.SOMenuId;
            if (null != value.RoleFeaturePermissionViewModel)
            {
                roleEntity.SORolePermissions = new List<SORolePermissionDto>();

                roleEntity.SORolePermissions = permissionMapper.ToEntities(value.RoleFeaturePermissionViewModel).ToList();
            }

            return roleEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns RoleViewModel</returns>
        public override RoleViewModel ToObject(SORoleDto entity)
        {
            var model = new RoleViewModel();
            model.Id = entity.Id;
            model.RoleName = entity.RoleName;
            model.Description = entity.Description;
            model.IsActive = entity.ActiveStatus;
            model.SOMenuId = entity.FeatureId;
            return model;
        }
    }
}