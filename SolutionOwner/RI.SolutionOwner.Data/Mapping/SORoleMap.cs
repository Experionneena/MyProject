﻿//-------------------------------------------------------
// <copyright file="SORoleMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Class SORoleMap
    /// </summary>
    public class SORoleMap : EntityTypeConfiguration<SORole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SORoleMap"/> class.
        /// </summary>
        public SORoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.RoleName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(x => x.FeatureId)
                .IsOptional();

            // Table & Column Mappings
            this.ToTable("SORoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ActiveStatus).HasColumnName("ActiveStatus");
            this.Property(t => t.CreatedDate)
                       .IsRequired()
                       .HasColumnType("datetime")
                       .HasColumnName("CreatedDate");
            this.Property(t => t.EditedDate)
                       .HasColumnType("datetime")
                       .HasColumnName("EditedDate");
        }
    }
}
