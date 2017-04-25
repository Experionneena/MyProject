//---------------------------------------------------------
// <copyright file="SPProductGroupMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// The Solution partner Product group mapper.
    /// </summary>
    public class SPProductGroupMapper : ObjectMapper<SPProductGroupDto, SPProductGroupViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPProductGroupMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public SPProductGroupMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Interface ISPProductGroup</returns>
        public override SPProductGroupDto ToEntity(SPProductGroupViewModel value)
        {
            var entity = CreateEntity();

            entity.Id = value.Id;
            entity.Name = value.Name;
            entity.ServiceProviderId = value.ServiceProviderId;
            entity.Description = value.Description;
            entity.ActiveStatus = value.ActiveStatus;
            entity.CreatedDate = value.CreatedDate;
            entity.EditedDate = value.EditedDate;
            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Model SPProductGroupViewModel</returns>
        public override SPProductGroupViewModel ToObject(SPProductGroupDto entity)
        {
            var value = new SPProductGroupViewModel();

            value.Id = entity.Id;
            value.Name = entity.Name;
            value.ServiceProviderId = entity.ServiceProviderId;
            value.Description = entity.Description;
            value.ActiveStatus = entity.ActiveStatus;
            value.CreatedDate = entity.CreatedDate;
            value.EditedDate = entity.EditedDate;
            return value;
        }
    }
}