//----------------------------------------------------------
// <copyright file="SORoleMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System;
using System.Linq;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.WebAPI.Ingest.Models;

namespace RI.SolutionOwner.WebAPI.Ingest.Mappers
{
    /// <summary>
    /// This class maps between ISORole and SORoleModel
    /// </summary>
    public class SORoleMapper : ObjectMapper<ISORole, SORoleModel>
    {
        ObjectMapper<ISORolePermission, SORolePermissionModel> _permissionMapper = null;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SORoleMapper" /> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="permissionMapper">The permission mapper.</param>
        public SORoleMapper(IServiceProvider services,
               ObjectMapper<ISORolePermission, SORolePermissionModel> permissionMapper) : base(services)
        {
            _permissionMapper = permissionMapper;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ISORole interface</returns>
        public override ISORole ToEntity(SORoleModel value)
        {
            var entity = CreateEntity();
            entity.Id = value.Id;
            entity.RoleName = value.RoleName;
            entity.Description = value.Description;
            entity.ActiveStatus = value.IsActive;
            ////entity.CreatedDate = value.CreatedDate;
            ////entity.EditedDate = value.EditedDate;
            if (null != value.RoleFeaturePermissionDto)
            {
                entity.SORolePermissions = _permissionMapper.ToEntities(value.RoleFeaturePermissionDto).ToList();
            }

            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SORoleModel object</returns>
        public override SORoleModel ToObject(ISORole entity)
        {
            var value = new SORoleModel();
            value.Id = entity.Id;
            value.RoleName = entity.RoleName;
            value.Description = entity.Description;
            value.IsActive = entity.ActiveStatus;
            ////value.CreatedDate = entity.CreatedDate;
            ////value.EditedDate = entity.EditedDate;
            return value;
        }
        #endregion
    }
}