//----------------------------------------------------------------------
// <copyright file="POSParameterCategoryMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// This Map class maps the map the POCO class POSParameterCategory to table
    /// </summary>
    public class POSParameterCategoryMap : EntityTypeConfiguration<POSParameterCategory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSParameterCategoryMap"/> class.
        /// </summary>
        public POSParameterCategoryMap()
        {
            ////Primary Key
            this.HasKey(t => t.Id);
            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");
            this.Property(t => t.ParameterCategory)
                .IsRequired()
                .HasMaxLength(50).HasColumnName("ParameterCategory");
            ////Table & Column Mappings
            this.ToTable("POSParameterCategories");
        }
    }
}
