// ---------------------------------------------------------
// <copyright file="SPFeatureMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// SPFeatureMap class
    /// </summary>
    public class SPFeatureMap : EntityTypeConfiguration<SPFeature>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPFeatureMap"/> class.
        /// </summary>
        public SPFeatureMap()
        {
            //// Primary Key
            this.HasKey(t => t.Id);
            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50).HasColumnName("FeatureName");
            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(50).HasColumnName("DisplayName");

            this.Property(t => t.ProgramLink).IsRequired().HasMaxLength(250).HasColumnName("ProgramLink");
            this.Property(t => t.IconClass).IsRequired().HasMaxLength(100).HasColumnName("IconClass");
            this.Property(t => t.SortOrder).IsRequired();
            this.Property(t => t.CreatedDate).IsRequired().HasColumnName("CreatedDate");
            this.Property(t => t.EditedDate).HasColumnName("EditedDate");
            this.Property(t => t.IsActive).IsRequired().HasColumnName("IsActive");

            // Table & Column Mappings
            this.ToTable("SPFeatures");
            this.HasRequired(t => t.Category)
                .WithMany(x => x.Features)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
            this.HasRequired(t => t.Hierarchy)
                .WithMany(x => x.Feature)
                .HasForeignKey(x => x.HierarchyId)
                .WillCascadeOnDelete(false);
        }
    }
}
