//---------------------------------------------------------
// <copyright file="SPProductGroupMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// The Solution partner Product group mapper.
    /// </summary>
    public class SPProductGroupMap : EntityTypeConfiguration<SPProductGroup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPProductGroupMap"/> class.
        /// </summary>
        public SPProductGroupMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ProductGroupId");

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("ProductGroupName");

            Property(x => x.Description)
                .HasMaxLength(2000)
                .HasColumnName("Description");

            Property(x => x.ActiveStatus)
                .IsRequired()
                .HasColumnName("ActiveStatus");

            HasRequired(x => x.ServiceProvider)
                .WithMany(x => x.ProductGroups)
                .HasForeignKey(x => x.ServiceProviderId)
                .WillCascadeOnDelete(false);
        }
    }
}
