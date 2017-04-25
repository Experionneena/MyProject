using RI.SolutionOwner.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;


namespace RI.SolutionOwner.Data.Mapping
{
   public class SPPUserRoleMap: EntityTypeConfiguration<SPPUserRole>
    {
        public SPPUserRoleMap()
        {
            // table name
            this.ToTable("SPPUserRoles");

            // primary key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");           

            this.HasRequired(t => t.SPPUser)
                .WithMany(x => x.SPPUserRoles)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            this.HasRequired(t => t.SPPRole)
               .WithMany(x => x.SPPUserRoles)
               .HasForeignKey(x => x.RoleId)
               .WillCascadeOnDelete(false);
        }
    }
}
