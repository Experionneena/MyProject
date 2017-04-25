//-----------------------------------------------------------
// <copyright file="ISOBranding.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------

namespace RI.SolutionOwner.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.Framework.Core.Data.Entities;

    /// <summary>
    /// ISOBranding exposes branding entities to services
    /// </summary>
    public interface ISOBranding : IEntity
    {
        /// <summary>
        /// Gets or sets owner name
        /// </summary>
        string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets company name
        /// </summary>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets product name
        /// </summary>
        string ProductName { get; set; }

        /// <summary>
        /// Gets or sets address
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets street name
        /// </summary>
        string StreetName { get; set; }

        /// <summary>
        /// Gets or sets area
        /// </summary>
        string Area { get; set; }

        /// <summary>
        /// Gets or sets zone
        /// </summary>
        string Zone { get; set; }

        /// <summary>
        /// Gets or sets city
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Gets or sets base currency id
        /// </summary>
        int BaseCurrencyID { get; set; }

        /// <summary>
        /// Gets or sets scheduler run time
        /// </summary>
        string SchedulerRunTime { get; set; }

        /// <summary>
        /// Gets or sets country name
        /// </summary>
        string CountryName { get; set; }

        /// <summary>
        /// Gets or sets state name
        /// </summary>
        string StateName { get; set; }

        /// <summary>
        /// Gets or sets billing person name
        /// </summary>
        string BillingPersonName { get; set; }

        /// <summary>
        /// Gets or sets billing designation
        /// </summary>
        string BillingDesignation { get; set; }

        /// <summary>
        /// Gets or sets billing work phone
        /// </summary>
        string BillingWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets billing mobile number
        /// </summary>
        string BillingMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets billing email
        /// </summary>
        string BillingEmail { get; set; }

        /// <summary>
        /// Gets or sets sales person name
        /// </summary>
        string SalesPersonName { get; set; }

        /// <summary>
        /// Gets or sets sales designation
        /// </summary>
        string SalesDesignation { get; set; }

        /// <summary>
        /// Gets or sets sales work phone
        /// </summary>
        string SalesWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets sales mobile number
        /// </summary>
        string SalesMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets sales email
        /// </summary>
        string SalesEmail { get; set; }

        /// <summary>
        /// Gets or sets image logo as byte array
        /// </summary>
        byte[] ImgLogo { get; set; }

        /// <summary>
        /// Gets or sets image thumb logo as byte array
        /// </summary>
        byte[] ImgThumbLogo { get; set; }
    }
}
