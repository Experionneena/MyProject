//-----------------------------------------------------------
// <copyright file="SOSolutionPartnerContactMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ---------------------------------------------------------
using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// The Solution Partner Contact mapper.
    /// </summary>
    public class SOSolutionPartnerContactMapper : ObjectMapper<SOSolutionPartnerContactDto, SOSolutionPartnerContactsViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerContactMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public SOSolutionPartnerContactMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Interface ISOSolutionPartnerContact</returns>
        public override SOSolutionPartnerContactDto ToEntity(SOSolutionPartnerContactsViewModel value)
        {
            var entity = CreateEntity();

            entity.Id = value.Id;
            entity.SolutionPartnerId = value.SolutionPartnerId;
            entity.PersonName = value.PersonName;
            entity.Designation = value.Designation;
            entity.PhoneWork = value.PhoneWork;
            entity.PhonePersonal = value.PhonePersonal;
            entity.EMail = value.EMail;
            entity.Remarks = value.Remarks;
            entity.CreatedDate = value.CreatedDate;
            entity.EditedDate = value.EditedDate;

            return entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Model SOSolutionPartnerContactsViewModel</returns>
        public override SOSolutionPartnerContactsViewModel ToObject(SOSolutionPartnerContactDto entity)
        {
            var value = new SOSolutionPartnerContactsViewModel();

            value.Id = entity.Id;
            value.SolutionPartnerId = entity.SolutionPartnerId;
            value.PersonName = entity.PersonName;
            value.Designation = entity.Designation;
            value.PhoneWork = entity.PhoneWork;
            value.PhonePersonal = entity.PhonePersonal;
            value.EMail = entity.EMail;
            value.Remarks = entity.Remarks;
            value.CreatedDate = entity.CreatedDate;
            value.EditedDate = entity.EditedDate;
            return value;
        }
    }
}