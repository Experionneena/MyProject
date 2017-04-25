//-----------------------------------------------------------
// <copyright file="BrandMapper.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Web.Mappers
{
    using System;
    using RI.SolutionOwner.Mapper;
    using RI.SolutionOwner.Web.Models;
    using DTOs;
    /// <summary>
    /// This class maps the brand entity object to and from branding view model
    /// </summary>
    public class BrandMapper : ObjectMapper<SOBrandingDto, BrandingViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandMapper"/> class.
        /// </summary>
        /// <param name="provider">Service provider</param>
        public BrandMapper(IServiceProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// This class maps branding view model to entity
        /// </summary>
        /// <param name="value">Branding View Model</param>
        /// <returns>brand entitiy</returns>
        public override SOBrandingDto ToEntity(BrandingViewModel value)
        {
            var brandEntity = CreateEntity();
            brandEntity.Id = value.Id;
            if (!string.IsNullOrEmpty(value.ImgData))
            {
                brandEntity.ImgLogo = Convert.FromBase64String(value.ImgData.Replace("data:image/png;base64,", string.Empty));
            }

            if (!string.IsNullOrEmpty(value.ImgThumbData))
            {
                brandEntity.ImgThumbLogo = Convert.FromBase64String(value.ImgThumbData.Replace("data:image/png;base64,", string.Empty));
            }

            brandEntity.OwnerName = value.OwnerName;
            brandEntity.CompanyName = value.CompanyName;
            brandEntity.ProductName = value.ProductName;
            brandEntity.BaseCurrencyID = value.BaseCurrencyID;
            brandEntity.SchedulerRunTime = value.SchedulerRunTime;
            brandEntity.Address = value.Address;
            brandEntity.StreetName = value.StreetName;
            brandEntity.Area = value.Area;
            brandEntity.Zone = value.Zone;
            brandEntity.City = value.City;
            brandEntity.CountryName = value.CountryName;
            brandEntity.StateName = value.StateName;
            brandEntity.BillingPersonName = value.BillingPersonName;
            brandEntity.BillingDesignation = value.BillingDesignation;
            brandEntity.BillingWorkPhone = value.BillingWorkPhone;
            brandEntity.BillingMobileNumber = value.BillingMobileNumber;
            brandEntity.BillingEmail = value.BillingEmail;
            brandEntity.SalesPersonName = value.SalesPersonName;
            brandEntity.SalesDesignation = value.SalesDesignation;
            brandEntity.SalesWorkPhone = value.SalesWorkPhone;
            brandEntity.SalesMobileNumber = value.SalesMobileNumber;
            brandEntity.SalesEmail = value.SalesEmail;
            return brandEntity;
        }

        /// <summary>
        /// This class maps brand entity to brand view model
        /// </summary>
        /// <param name="entity">brand entity</param>
        /// <returns>brand view model</returns>
        public override BrandingViewModel ToObject(SOBrandingDto entity)
        {
            var model = new BrandingViewModel();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.ImgData = entity.ImgLogo == null ? string.Empty : "data:image/png;base64," + Convert.ToBase64String(entity.ImgLogo);
                model.ImgThumbData = entity.ImgThumbLogo == null ? string.Empty : "data:image/png;base64," + Convert.ToBase64String(entity.ImgThumbLogo);
                model.OwnerName = entity.OwnerName;
                model.CompanyName = entity.CompanyName;
                model.ProductName = entity.ProductName;
                model.BaseCurrencyID = entity.BaseCurrencyID;
                model.SchedulerRunTime = entity.SchedulerRunTime;
                model.Address = entity.Address;
                model.StreetName = entity.StreetName;
                model.Area = entity.Area;
                model.Zone = entity.Zone;
                model.City = entity.City;
                model.CountryName = entity.CountryName;
                model.StateName = entity.StateName;
                model.BillingPersonName = entity.BillingPersonName;
                model.BillingDesignation = entity.BillingDesignation;
                model.BillingWorkPhone = entity.BillingWorkPhone;
                model.BillingMobileNumber = entity.BillingMobileNumber;
                model.BillingEmail = entity.BillingEmail;
                model.SalesPersonName = entity.SalesPersonName;
                model.SalesDesignation = entity.SalesDesignation;
                model.SalesWorkPhone = entity.SalesWorkPhone;
                model.SalesMobileNumber = entity.SalesMobileNumber;
                model.SalesEmail = entity.SalesEmail;
            }

            return model;
        }
    }
}