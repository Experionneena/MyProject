//-----------------------------------------------------
// <copyright file="SPRoleMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// SP Role Map class
    /// </summary>
    public class SPRoleMap : EntityTypeConfiguration<SPRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPRoleMap"/> class.
        /// </summary>
        public SPRoleMap()
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
            this.ToTable("SPRoles");
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
            this.HasRequired(t => t.Hierarchy)
              .WithMany(x => x.Role)
              .HasForeignKey(x => x.HierarchyId)
              .WillCascadeOnDelete(false);
        }
    }
}
