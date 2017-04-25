// ---------------------------------------------------------
// <copyright file="OwnerUserMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.Collections.Generic;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.WebAPI.Mappers
{
    /// <summary>
    /// This class maps ISOUser to OwnerUserModel and viceversa.
    /// </summary>
    public class OwnerUserMapper : RI.SolutionOwner.Mapper.ObjectMapper<SOUserDto, OwnerUserModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerUserMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public OwnerUserMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns ISOUser entity</returns>
        public override SOUserDto ToEntity(OwnerUserModel model)
        {
            var entity = CreateEntity();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Email = model.Email;
            ////entity.LastLoginDate = model.LastLoginDate;
            entity.IsActive = model.IsActive;
            entity.IsBlocked = model.IsBlocked;
            entity.RoleIdList = model.RoleIdList;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns OwnerUserModel model.</returns>
        public override OwnerUserModel ToObject(SOUserDto entity)
        {
            var model = new OwnerUserModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Email = entity.Email;
            model.LastLoginDate = entity.LastLoginDate == null ? null : entity.LastLoginDate.Value.ToLocalTime().ToString("g");
            model.IsActive = entity.IsActive;
            model.RoleNameList = entity.RoleNameList as List<string>;
            model.RoleIdList = entity.RoleIdList as List<int>;
            model.IsBlocked = entity.IsBlocked ?? false;
            model.CreatedDate = entity.CreatedDate == null ? null : entity.CreatedDate.Value.ToLocalTime().ToString("g");
            model.EditedDate = entity.EditedDate == null ? null : entity.EditedDate.Value.ToLocalTime().ToString("g");
            return model;
        }
    }
}
