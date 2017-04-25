//-----------------------------------------------------
// <copyright file="SPPRolePermissionMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// This Map class maps the map the POCO class to table
    /// </summary>
    public class SPPRolePermissionMap : EntityTypeConfiguration<SPPRolePermission>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPPRolePermissionMap"/> class.
        /// </summary>
        public SPPRolePermissionMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.RoleId)
                .IsRequired();
            this.Property(x => x.FeatureId)
                .IsRequired();
            this.Property(x => x.CreatePermission)
                .IsRequired();
            this.Property(x => x.UpdatePermission)
                .IsRequired();
            this.Property(x => x.DeletePermission)
                .IsRequired();
            this.Property(x => x.ReadPermission)
                .IsRequired();
            this.Property(x => x.DeAvtivatePermission)
                .IsRequired();
            this.Property(x => x.ApprovePermission)
                .IsRequired();
            this.Property(x => x.CreatedDate)
               .IsRequired()
               .HasColumnType("datetime");
            this.Property(x => x.EditedDate)
                .IsRequired()
                .HasColumnType("datetime");
            this.HasRequired(x => x.Roles)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.RoleId)
                .WillCascadeOnDelete(true);
            this.HasRequired(x => x.Features)
                .WithMany(x => x.PartnerPortalRolePermissions)
                .HasForeignKey(x => x.FeatureId)
                .WillCascadeOnDelete(false);
            this.ToTable("SPPRolePermissions");
        }
    }
}
