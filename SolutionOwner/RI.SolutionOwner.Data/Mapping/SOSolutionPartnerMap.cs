//---------------------------------------------------------
// <copyright file="SOSolutionPartnerMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// The SO Solution partner entity mapper.
    /// </summary>
    public class SOSolutionPartnerMap : EntityTypeConfiguration<SOSolutionPartner>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerMap"/> class.
        /// </summary>
        public SOSolutionPartnerMap()
        {
            this.ToTable("SOSolutionPartners");

            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.SftpFolderPath).HasMaxLength(500).HasColumnName("SftpFolderPath");
            this.HasRequired(x => x.SPHierarchy).WithRequiredPrincipal(y => y.SOSolutionPartner);
            this.Property(x => x.Name).HasMaxLength(100)
                                 .HasColumnName("Name")
                                 .IsRequired();
            this.Property(x => x.AdminEmail).HasMaxLength(100)
                                       .HasColumnName("AdminEmail")
                                       .IsRequired();
            this.Property(x => x.CurrencyId).HasColumnName("CurrencyId")
                                       .IsRequired();
            this.Property(x => x.SchedulerTime).HasColumnType("datetime")
                                          .HasColumnName("SchedulerTime")
                                          .IsOptional();
            this.Property(x => x.POSPrintingQty).HasColumnName("POSPrintingQty")
                                           .IsRequired();
            this.Property(x => x.CR).HasMaxLength(100)
                               .HasColumnName("CR")
                               .IsOptional();
            this.Property(x => x.CRExpiryDate).HasColumnType("datetime")
                                         .HasColumnName("CRExpiryDate")
                                         .IsOptional();
            this.Property(x => x.CRProof).HasColumnName("CRProof")
                                    .IsOptional();
            this.Property(x => x.Password).HasMaxLength(50)
                                     .HasColumnName("Password")
                                     .IsOptional();
            this.Property(x => x.EmailPassword).HasColumnName("EmailPassword");

            this.Property(x => x.Name).HasMaxLength(100)
                                 .HasColumnName("Name")
                                 .IsRequired();

            this.Property(x => x.AdminEmail).HasMaxLength(100)
                                       .HasColumnName("AdminEmail")
                                       .IsRequired();

            this.Property(x => x.CurrencyId).HasColumnName("CurrencyId")
                                       .IsRequired();

            this.Property(x => x.SchedulerTime).HasColumnType("datetime")
                                          .HasColumnName("SchedulerTime")
                                          .IsOptional();

            this.Property(x => x.POSPrintingQty).HasColumnName("POSPrintingQty")
                                           .IsRequired();

            this.Property(x => x.CR).HasMaxLength(100)
                               .HasColumnName("CR")
                               .IsOptional();

            this.Property(x => x.CRExpiryDate).HasColumnType("datetime")
                                         .HasColumnName("CRExpiryDate")
                                         .IsOptional();

            this.Property(x => x.CRProof).HasColumnName("CRProof")
                                    .IsOptional();

            this.Property(x => x.Password).HasMaxLength(50)
                                     .HasColumnName("Password")
                                     .IsOptional();

            this.Property(x => x.EmailPassword).HasColumnName("EmailPassword");

            this.Property(x => x.ResetPasswordNextLogin).HasColumnName("ResetPasswordNextLogin");

            this.Property(x => x.IsActive).HasColumnName("IsActive");

            this.Property(t => t.SftpFolderPath).HasMaxLength(500)
                                                .HasColumnName("SftpFolderPath");

            this.HasOptional(s => s.SPAddress)
                .WithRequired(s => s.SOSolutionPartner)
                .WillCascadeOnDelete(true);

            this.HasOptional(s => s.SPHierarchy)
                .WithRequired(s => s.SOSolutionPartner)
                .WillCascadeOnDelete(true);
        }
    }
}