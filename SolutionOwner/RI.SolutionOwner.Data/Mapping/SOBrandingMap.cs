//-----------------------------------------------------------
// <copyright file="SOBrandingMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.SolutionOwner.Data.Entities;

    /// <summary>
    /// This class maps the entity SOBranding to physical database
    /// </summary>
    public class SOBrandingMap : EntityTypeConfiguration<SOBranding>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOBrandingMap"/> class.
        /// </summary>
        public SOBrandingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            
            // Properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.OwnerName).IsRequired().HasMaxLength(100).HasColumnName("OwnerName");
            this.Property(t => t.CompanyName).HasMaxLength(100).HasColumnName("CompanyName");
            this.Property(t => t.ProductName).IsRequired().HasMaxLength(100).HasColumnName("ProductName");
            this.Property(t => t.BaseCurrencyID).IsRequired().HasColumnName("BaseCurrencyID");
            this.Property(t => t.SchedulerRunTime).HasColumnName("SchedulerRunTime");
            this.Property(t => t.Address).HasMaxLength(250).HasColumnName("Address");
            this.Property(t => t.StreetName).HasMaxLength(250).HasColumnName("StreetName");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Zone).HasColumnName("Zone");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.BillingPersonName).HasColumnName("BillingPersonName");
            this.Property(t => t.BillingDesignation).HasColumnName("BillingDesignation");
            this.Property(t => t.BillingWorkPhone).HasColumnName("BillingWorkPhone");
            this.Property(t => t.BillingMobileNumber).HasColumnName("BillingMobileNumber");
            this.Property(t => t.BillingEmail).HasColumnName("BillingEmail");

            this.Property(t => t.SalesPersonName).HasColumnName("SalesPersonName");
            this.Property(t => t.SalesDesignation).HasColumnName("SalesDesignation");
            this.Property(t => t.SalesWorkPhone).HasColumnName("SalesWorkPhone");
            this.Property(t => t.SalesMobileNumber).HasColumnName("SalesMobileNumber");
            this.Property(t => t.SalesEmail).HasColumnName("SalesEmail");
            this.Property(t => t.ImgLogo).HasColumnName("ImgLogo");
            this.Property(t => t.ImgThumbLogo).HasColumnName("ImgThumbLogo");

            // Table & Column Mappings
            this.ToTable("SOBrandings");
        }
    }
}
