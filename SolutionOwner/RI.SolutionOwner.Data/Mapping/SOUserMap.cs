// ---------------------------------------------------------
// <copyright file="SOUserMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Class SOUserMap
    /// </summary>
    public class SOUserMap : EntityTypeConfiguration<SOUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOUserMap" /> class.
        /// </summary>
        public SOUserMap()
        {
            this.ToTable("SOUsers");

            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.Name)
                           .IsRequired()
                           .HasMaxLength(100)
                           .HasColumnName("Name");
            //// Unique Key
            this.Property(t => t.Email)
                          .IsRequired()
                          .HasMaxLength(100)
                          .HasColumnName("Email")
                          .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UK_EMAILID") { IsUnique = true }));

            this.Property(t => t.IsBlocked)
                .HasColumnName("IsBlocked").IsOptional();

            this.Property(t => t.LastLoginDate)
                         .HasColumnType("datetime")
                         .HasColumnName("LastLoginDate")
                         .IsOptional();

            this.Property(t => t.IsActive)
                         .IsRequired()
                         .HasColumnName("IsActive");
        }
    }
}