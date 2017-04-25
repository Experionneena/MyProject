//---------------------------------------------------------
// <copyright file="POSParameterMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Supplier Map
    /// </summary>
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierMap"/> class.
        /// </summary>
        public SupplierMap()
        {
            ////Primary Key
            this.HasKey(t => t.Id);
            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");
            this.Property(t => t.SupplierName)
                .IsRequired()
                .HasColumnName("SupplierName");
            this.Property(t => t.Address).IsRequired().HasColumnName("Address");
            this.Property(t => t.StreetName).IsRequired().HasColumnName("StreetName");
            this.Property(t => t.State).IsRequired().HasColumnName("State");
            this.Property(t => t.Country).IsRequired().HasColumnName("Country");
            this.Property(t => t.ContactPerson).IsRequired().HasColumnName("ContactPerson");
            this.Property(t => t.Designation).IsRequired().HasColumnName("Designation");
            this.Property(t => t.WorkPhone).IsRequired().HasColumnName("WorkPhone");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.Email).IsRequired().HasColumnName("Email");
            this.Property(t => t.LPOContactPerson).IsRequired().HasColumnName("LPOContactPerson");
            this.Property(t => t.LPODesignation).IsRequired().HasColumnName("LPODesignation");
            this.Property(t => t.LPOWorkPhone).HasColumnName("LPOWorkPhone");
            this.Property(t => t.LPOMobileNumber).HasColumnName("LPOMobileNumber");
            this.Property(t => t.LPOEmail).HasColumnName("LPOEmail");
            ////Table & Column Mappings
            this.ToTable("Supplier");
        }
    }
}
