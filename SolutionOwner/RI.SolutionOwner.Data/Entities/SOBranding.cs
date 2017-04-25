//-----------------------------------------------------------
// <copyright file="SOBranding.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data.Entities;
    using RI.SolutionOwner.Data.Contracts;

    /// <summary>
    /// This class implements the properties exposed in ISOBranding
    /// </summary>
    public class SOBranding : BaseEntity, ISOBranding
    {
        /// <summary>
        /// Gets or sets owner name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets street name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets area
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets zone
        /// </summary>
        public string Zone { get; set; }

        /// <summary>
        /// Gets or sets city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets base currency id
        /// </summary>
        public int BaseCurrencyID { get; set; }

        /// <summary>
        /// Gets or sets scheduler run time
        /// </summary>
        public string SchedulerRunTime { get; set; }

        /// <summary>
        /// Gets or sets country name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets state name
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets billing person name
        /// </summary>
        public string BillingPersonName { get; set; }

        /// <summary>
        /// Gets or sets billing designation
        /// </summary>
        public string BillingDesignation { get; set; }

        /// <summary>
        /// Gets or sets billing work phone
        /// </summary>
        public string BillingWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets billing mobile number
        /// </summary>
        public string BillingMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets billing email
        /// </summary>
        public string BillingEmail { get; set; }

        /// <summary>
        /// Gets or sets sales person name
        /// </summary>
        public string SalesPersonName { get; set; }

        /// <summary>
        /// Gets or sets sales designation
        /// </summary>
        public string SalesDesignation { get; set; }

        /// <summary>
        /// Gets or sets sales work phone
        /// </summary>
        public string SalesWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets sales mobile number
        /// </summary>
        public string SalesMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets sales email
        /// </summary>
        public string SalesEmail { get; set; }

        /// <summary>
        /// Gets or sets image logo as byte array
        /// </summary>
        public byte[] ImgLogo { get; set; }

        /// <summary>
        /// Gets or sets image thumb logo as byte array
        /// </summary>
        public byte[] ImgThumbLogo { get; set; }
    }
}