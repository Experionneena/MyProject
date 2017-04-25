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
    public class SPPUserMap : EntityTypeConfiguration<SPPUser>
    {
        public SPPUserMap()
        {
            this.ToTable("SPPUsers");
            // Primary Key
            this.HasKey(t => t.Id);


            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.Name)
                           .IsRequired()
                           .HasMaxLength(100)
                           .HasColumnName("Name");

            this.Property(t => t.WorkPhone)
                           .IsRequired()
                           .HasMaxLength(15)
                           .HasColumnName("WorkPhone");

            this.Property(t => t.Mobile)
                           .IsRequired()
                           .HasMaxLength(15)
                           .HasColumnName("Mobile");

            this.Property(t => t.Password)
                           .IsRequired()
                           .HasColumnName("Password");

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

            this.HasRequired(t => t.Hierarchy)
                .WithMany(x => x.PartnerPortalUsers)
                .HasForeignKey(x => x.HierarchyId)
                .WillCascadeOnDelete(false);

            this.HasOptional(t => t.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .WillCascadeOnDelete(false);

        }
    }
}
