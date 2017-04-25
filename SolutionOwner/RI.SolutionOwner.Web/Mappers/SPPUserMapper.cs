// ---------------------------------------------------------
// <copyright file="SPPUserMapper.cs" company="RechargeIndia">
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
    /// This class maps ISOUser to SPPUserViewModel and viceversa.
    /// </summary>
    public class SPPUserMapper : RI.SolutionOwner.Mapper.ObjectMapper<SPPUserDto, SPPUserViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPPUserMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public SPPUserMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns ISOUser entity</returns>
        public override SPPUserDto ToEntity(SPPUserViewModel model)
        {
            var entity = new SPPUserDto();
            entity.Id = model.Id;
            //entity.CreatedDate = Convert.ToDateTime(model.CreatedDate);
            //entity.EditedDate = Convert.ToDateTime(model.EditedDate);
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.WorkPhone = model.WorkPhone;
            entity.Mobile = model.Mobile;
            entity.HierarchyId = model.HierarchyId;
            entity.Password = model.Password;
            entity.ParentId = model.ParentId;
            //entity.LastLoginDate = Convert.ToDateTime(model.LastLoginDate);
            entity.RoleIdList = model.RoleIdList;
            entity.RoleNameList = model.RoleNameList;
            entity.IsActive = model.IsActive;
            entity.IsBlocked = model.IsBlocked;
            entity.RoleIdList = model.RoleIdList;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns SPPUserViewModel model.</returns>
        public override SPPUserViewModel ToObject(SPPUserDto entity)
        {
            var model = new SPPUserViewModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Email = entity.Email;
            model.WorkPhone = entity.WorkPhone;
            model.Mobile = entity.Mobile;
            model.HierarchyId = entity.HierarchyId;
            model.Password = entity.Password;
            model.ParentId = entity.ParentId;
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
