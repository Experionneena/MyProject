//------------------------------------------------------
// <copyright file="SPPRoleMapper.cs" company="RechargeIndia">
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
    /// This class maps ISPPRole to SPPRoleViewModel and viceversa.
    /// </summary>
    public class SPPRoleMapper : ObjectMapper<SPPRoleDto, SPPRoleViewModel>
    {
        /// <summary>
        /// The _permission mapper
        /// </summary>
        private ObjectMapper<SPPRolePermissionDto, SPPRoleFeaturePermissionViewModel> permissionMapper = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPPRoleMapper" /> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="permissionMapper">The permission mapper.</param>
        public SPPRoleMapper(
            IServiceProvider provider, ObjectMapper<SPPRolePermissionDto, SPPRoleFeaturePermissionViewModel> permissionMapper) : base(provider)
        {
            this.permissionMapper = permissionMapper;
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns ISPPRole entity</returns>
        public override SPPRoleDto ToEntity(SPPRoleViewModel value)
        {
            var roleEntity = new SPPRoleDto();
            roleEntity.Id = value.Id;
            roleEntity.RoleName = value.RoleName;
            roleEntity.Description = value.Description;
            roleEntity.ActiveStatus = value.IsActive;
            roleEntity.FeatureId = value.SPMenuId;
            roleEntity.HierarchyId = value.HierarchyId;
            if (null != value.SPPRoleFeaturePermissionViewModel)
            {
                roleEntity.SPPRolePermissions = new List<SPPRolePermissionDto>();

                roleEntity.SPPRolePermissions = permissionMapper.ToEntities(value.SPPRoleFeaturePermissionViewModel).ToList();
            }

            return roleEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns SPPRoleViewModel</returns>
        public override SPPRoleViewModel ToObject(SPPRoleDto entity)
        {
            var model = new SPPRoleViewModel();
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