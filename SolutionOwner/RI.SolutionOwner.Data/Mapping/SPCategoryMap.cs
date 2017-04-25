// ---------------------------------------------------------
// <copyright file="SPCategoryMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Solution Partner Category Map
    /// </summary>
    public class SPCategoryMap : EntityTypeConfiguration<SPCategory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCategoryMap"/> class.
        /// </summary>
        public SPCategoryMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");
            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(50).HasColumnName("CategoryName");
            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(50).HasColumnName("DisplayName");
            this.Property(t => t.CategoryDescription).IsOptional().HasMaxLength(500).HasColumnName("CategoryDescription");
            this.Property(t => t.IconClass).IsRequired().HasMaxLength(100).HasColumnName("IconClass");
            this.Property(t => t.SortOrder).IsRequired().HasColumnName("SortOrder");
            this.HasOptional(t => t.Category).WithMany(x => x.Categories)
                .HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false);
            this.ToTable("SPCategory");
        }
    }
}
