//-----------------------------------------------------------
// <copyright file="SupplierMapper.cs" company="RechargeIndia">
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
    /// Class CategoryMapper
    /// </summary>
    public class SupplierMapper : ObjectMapper<SupplierDto, SupplierViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMapper"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public SupplierMapper(IServiceProvider services) : base(services)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Interface ISOCategory</returns>
        public override SupplierDto ToEntity(SupplierViewModel value)
        {
            var Entity = new SupplierDto();
            Entity.Id = value.Id;
            Entity.SupplierName = value.SupplierName;
            Entity.Address = value.Address;
            Entity.StreetName = value.StreetName;
            Entity.State = value.State;
            Entity.Country = value.Country;
            Entity.ContactPerson = value.ContactPerson;
            Entity.Designation = value.Designation;
            Entity.ContactPerson = value.ContactPerson;
            Entity.WorkPhone = value.WorkPhone;
            Entity.MobileNumber = value.MobileNumber;
            Entity.Email = value.Email;
            Entity.LPOContactPerson = value.LPOContactPerson;
            Entity.LPOWorkPhone = value.LPOWorkPhone;
            Entity.LPOMobileNumber = value.LPOMobileNumber;
            Entity.LPOEmail = value.LPOEmail;
            return Entity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Model CategoryViewModel</returns>
        public override SupplierViewModel ToObject(SupplierDto entity)
        {
            var model = new SupplierViewModel();
            model.Id = entity.Id;
            model.Id = entity.Id;
            model.SupplierName = entity.SupplierName;
            model.Address = entity.Address;
            model.StreetName = entity.StreetName;
            model.State = entity.State;
            model.Country = entity.Country;
            model.ContactPerson = entity.ContactPerson;
            model.Designation = entity.Designation;
            model.ContactPerson = entity.ContactPerson;
            model.WorkPhone = entity.WorkPhone;
            model.MobileNumber = entity.MobileNumber;
            model.Email = entity.Email;
            model.LPOContactPerson = entity.LPOContactPerson;
            model.LPOWorkPhone = entity.LPOWorkPhone;
            model.LPOMobileNumber = entity.LPOMobileNumber;
            model.LPOEmail = entity.LPOEmail;
            return model;
        }
    }
}