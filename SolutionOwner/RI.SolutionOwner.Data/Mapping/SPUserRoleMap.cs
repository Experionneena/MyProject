using RI.SolutionOwner.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;


namespace RI.SolutionOwner.Data.Mapping
{
   public class SPUserRoleMap: EntityTypeConfiguration<SPUserRole>
    {
        public SPUserRoleMap()
        {
            // table name
            this.ToTable("SPUserRoles");

            // primary key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");           

            this.HasRequired(t => t.SPUser)
                .WithMany(x => x.SPUserRoles)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);


            this.HasRequired(t => t.SPRole)
               .WithMany(x => x.SPUserRoles)
               .HasForeignKey(x => x.RoleId)
               .WillCascadeOnDelete(false);
        }
    }
}
