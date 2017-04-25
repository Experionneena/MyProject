//------------------------------------------------------
// <copyright file="POSParameterMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//--------------------------------------------------------

using System;
using RI.SolutionOwner.Mapper;
using RI.SolutionOwner.Web.Models;
using RI.SolutionOwner.Web.DTOs;

namespace RI.SolutionOwner.Web.Mappers
{
    /// <summary>
    /// This class maps between IPOSParameter and POSParameterModel
    /// </summary>
    public class POSRegistrationMapper : ObjectMapper<POSDto, POSViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSParameterMapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public POSRegistrationMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// To the entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns IPOSParameterCategory entity.</returns>
        public override POSDto ToEntity(POSViewModel model)
        {
            var posEntity = new POSDto();
            posEntity.Id = model.Id;
            posEntity.POSNumber = model.POSNumber;
            posEntity.SerialNumber = model.SerialNumber;
            posEntity.ModelNumber = model.ModelNumber;
            posEntity.PurchaseLPO = model.PurchaseLPO;
            posEntity.WarrantyExpiry = model.WarrantyExpiry;
            posEntity.SupplierId = model.SupplierId;
            posEntity.ManagedById = model.ManagedById;
            posEntity.Manufacturer = model.Manufacturer;
            posEntity.ManufacturingYear = model.ManufacturingYear;
            posEntity.OsVersion = model.OsVersion;
            posEntity.Remarks = model.Remarks;      
            posEntity.IsActive = model.IsActive;
            posEntity.CreatedDate = model.CreatedDate;
            posEntity.EditedDate = model.EditedDate;
            return posEntity;
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>returns POSParmeterCategoryModel model.</returns>
        public override POSViewModel ToObject(POSDto entity)
        {
            var model = new POSViewModel();
            model.Id = entity.Id;
            model.POSNumber = entity.POSNumber;
            model.SerialNumber = entity.SerialNumber;
            model.ModelNumber = entity.ModelNumber;
            model.PurchaseLPO = entity.PurchaseLPO;
            model.WarrantyExpiry = entity.WarrantyExpiry;
            model.SupplierId = entity.SupplierId;
            model.Manufacturer = entity.Manufacturer;
            model.ManufacturingYear = entity.ManufacturingYear;
            model.OsVersion = entity.OsVersion;
            model.Remarks = entity.Remarks;
            model.ManagedById = entity.ManagedById;
            model.IsActive = entity.IsActive;
            model.CreatedDate = entity.CreatedDate;
            model.EditedDate = entity.EditedDate;
            return model;
        }
    }
}