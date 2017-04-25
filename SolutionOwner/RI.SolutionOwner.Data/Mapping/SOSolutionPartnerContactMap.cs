//---------------------------------------------------------
// <copyright file="SOSolutionPartnerContactMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// The Solution partner contact entity mapper.
    /// </summary>
    public class SOSolutionPartnerContactMap : EntityTypeConfiguration<SOSolutionPartnerContact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOSolutionPartnerContactMap"/> class.
        /// </summary>
        public SOSolutionPartnerContactMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            Property(x => x.SolutionPartnerId)
                .IsRequired();

            Property(x => x.PersonName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Designation)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.PhoneWork)
                .IsOptional()
                .HasMaxLength(20);

            Property(x => x.PhonePersonal)
                .IsOptional()
                .HasMaxLength(20);

            Property(x => x.EMail)
                .IsOptional()
                .HasMaxLength(50);

            Property(x => x.Remarks)
                .IsOptional()
                .HasMaxLength(200);

            HasRequired(x => x.SolutionPartner)
                   .WithMany(x => x.Contacts)
                   .HasForeignKey(x => x.SolutionPartnerId)
                   .WillCascadeOnDelete(true);
        }
    }
}
