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
    /// This Map class maps the map the POCO class POSParameter to table
    /// </summary>
    public class POSRegistrationMap : EntityTypeConfiguration<POS>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSRegistrationrMap"/> class.
        /// </summary>
        public POSRegistrationMap()
        {
            ////Primary Key
            this.HasKey(t => t.Id);
            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");
            this.Property(t => t.POSNumber)
                .IsRequired()
                .HasColumnName("PosNumber");
            this.Property(t => t.SerialNumber).IsRequired().HasColumnName("SerialNumber");
            this.Property(t => t.ModelNumber).IsRequired().HasColumnName("ModelNumber");
            this.Property(t => t.PurchaseLPO).IsRequired().HasColumnName("PurchaseLPO");
            this.Property(t => t.WarrantyExpiry).IsRequired().HasColumnName("WarrantyExpiry");
            this.Property(t => t.SupplierId).IsRequired().HasColumnName("SupplierId");
            this.Property(t => t.Manufacturer).IsRequired().HasColumnName("Manufacturer");
            this.Property(t => t.ManufacturingYear).IsRequired().HasColumnName("ManufacturingYear");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.IsActive).IsRequired().HasColumnName("IsActive");
            this.Property(t => t.OsVersion).HasColumnName("OsVersion");
            this.Property(t => t.ManagedById).IsRequired().HasColumnName("ManagedById");
            this.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
            ////Table & Column Mappings
            this.ToTable("POS");
            this.HasRequired(t => t.Suppliers)
              .WithMany(x => x.PosList)
              .HasForeignKey(x => x.SupplierId)
              .WillCascadeOnDelete(false);
            this.HasRequired(t => t.SPPUsers)
             .WithMany(x => x.PosUserList)
             .HasForeignKey(x => x.ManagedById)
             .WillCascadeOnDelete(false);
        }
    }
}
