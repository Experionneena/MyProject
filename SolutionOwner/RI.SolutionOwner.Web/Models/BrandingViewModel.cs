//-----------------------------------------------------------
// <copyright file="BrandingViewModel.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RI.SolutionOwner.Web.Models
{
    /// <summary>
    /// This class defines property for brand view model
    /// </summary>
    public class BrandingViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>       
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the owner name.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the zone.
        /// </summary>
        public string Zone { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the currency list.
        /// </summary>
        public IEnumerable<SelectListItem> BaseCurrencyList { get; set; }

        /// <summary>
        /// Gets or sets the base currency
        /// </summary>
        public int BaseCurrencyID { get; set; }

        /// <summary>
        /// Gets or sets the currency name
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the country name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the state name
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets the billing person name
        /// </summary>
        public string BillingPersonName { get; set; }

        /// <summary>
        /// Gets or sets the billing designation
        /// </summary>
        public string BillingDesignation { get; set; }

        /// <summary>
        /// Gets or sets the billing work phone
        /// </summary>
        public string BillingWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the billing mobile number
        /// </summary>
        public string BillingMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the billing email
        /// </summary>
        public string BillingEmail { get; set; }

        /// <summary>
        /// Gets or sets the sales person name
        /// </summary>
        public string SalesPersonName { get; set; }

        /// <summary>
        /// Gets or sets the sales designation
        /// </summary>
        public string SalesDesignation { get; set; }

        /// <summary>
        /// Gets or sets the sales work phone
        /// </summary>
        public string SalesWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the sales mobile number
        /// </summary>
        public string SalesMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the sales email
        /// </summary>
        public string SalesEmail { get; set; }

        /// <summary>
        /// Gets or sets the logo file name
        /// </summary>
        public string LogoFileName { get; set; }

        /// <summary>
        /// Gets or sets the image data
        /// </summary>
        public string ImgData { get; set; }

        /// <summary>
        /// Gets or sets the thumb image data
        /// </summary>
        public string ImgThumbData { get; set; }

        /// <summary>
        /// Gets or sets the image byte array
        /// </summary>
        public byte[] ImgLogo { get; set; }

        /// <summary>
        /// Gets or sets the scheduler run time
        /// </summary>
        public string SchedulerRunTime { get; set; }

        /// <summary>
        /// Gets or sets the response MSG.
        /// </summary>
        /// <value>
        /// The response MSG.
        /// </value>
        public string ResponseMsg { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [response status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [response status]; otherwise, <c>false</c>.
        /// </value>
        public bool ResponseStatus { get; set; }
    }
}