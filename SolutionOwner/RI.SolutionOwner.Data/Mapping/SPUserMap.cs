using RI.SolutionOwner.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Mapping
{
    public class SPUserMap : EntityTypeConfiguration<SPUser>
    {
        public SPUserMap()
        {
            this.ToTable("SPUsers");
            // Primary Key
            this.HasKey(t => t.Id);


            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.Name)
                           .IsRequired()
                           .HasMaxLength(100)
                           .HasColumnName("Name");
            // Unique Key
            this.Property(t => t.Email)
                          .IsRequired()
                          .HasMaxLength(100)
                          .HasColumnName("Email").HasColumnAnnotation
                          (IndexAnnotation.AnnotationName, new IndexAnnotation
                          (new IndexAttribute("UK_EMAILID") { IsUnique = true }));

            this.Property(t => t.IsBlocked)
                .HasColumnName("IsBlocked").IsOptional();

            //this.Property(t => t.PortalHome)
            //    .HasColumnName("PortalHome");


            this.Property(t => t.LastLoginDate)
                         .HasColumnType("datetime")
                         .HasColumnName("LastLoginDate");

            this.Property(t => t.IsActive)
                         .IsRequired()
                         .HasColumnName("IsActive");

        }
    }
}
