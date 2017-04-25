// ---------------------------------------------------------
// <copyright file="SOUserRoleMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Class SOUserRoleMaps
    /// </summary>
    public class SOUserRoleMap : EntityTypeConfiguration<SOUserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOUserRoleMap"/> class.
        /// </summary>
        public SOUserRoleMap()
        {
            // table name
            this.ToTable("SOUserRoles");

            // primary key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.HasRequired(t => t.SOUser)
                .WithMany(x => x.SOUserRoles)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            this.HasRequired(t => t.SORole)
               .WithMany(x => x.SOUserRoles)
               .HasForeignKey(x => x.RoleId)
               .WillCascadeOnDelete(false);
        }
    }
}
