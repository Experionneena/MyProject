//------------------------------------------------------
// <copyright file="SPRoleMapper.cs" company="RechargeIndia">
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
    /// This class maps SPRoleDto to SPRoleViewModel and viceversa.
    /// </summary>
    public class SPRoleMapper : ObjectMapper<SPRoleDto, SPRoleViewModel>
    {
        /// <summary>
        /// The _permission mapper
        /// </summary>
        private ObjectMapper<SPRolePermissionDto, SPRoleFeaturePermissionViewModel> permissionMapper = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleMapper" /> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="permissionMapper">The permission mapper.</param>
        public SPRoleMapper(
            IServiceProvider provider, ObjectMapper<SPRolePermissionDto, SPRoleFeaturePermissionViewModel> permissionMapper) : base(provider)
        {
            this.permissionMapper = permissionMapper;
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns SPRoleDto entity</returns>
        public override SPRoleDto ToEntity(SPRoleViewModel value)
        {
            var roleEntity = new SPRoleDto();
            roleEntity.Id = value.Id;
            roleEntity.RoleName = value.RoleName;
            roleEntity.Description = value.Description;
            roleEntity.ActiveStatus = value.IsActive;
            roleEntity.FeatureId = value.SPMenuId;
            roleEntity.HierarchyId = value.HierarchyId;
            if (null != value.SPRoleFeaturePermissionViewModel)
            {
                roleEntity.SPRolePermissions = new List<SPRolePermissionDto>();

                roleEntity.SPRolePermissions = permissionMapper.ToEntities(value.SPRoleFeaturePermissionViewModel).ToList();
            }

            return roleEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns SPRoleViewModel</returns>
        public override SPRoleViewModel ToObject(SPRoleDto entity)
        {
            var model = new SPRoleViewModel();
            model.Id = entity.Id;
            model.RoleName = entity.RoleName;
            model.Description = entity.Description;
            model.IsActive = entity.ActiveStatus;
            model.SPMenuId = entity.FeatureId;
            model.HierarchyId = entity.HierarchyId;
            return model;
        }
    }
}