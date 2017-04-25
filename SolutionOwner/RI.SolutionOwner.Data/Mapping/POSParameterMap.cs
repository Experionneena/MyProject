//---------------------------------------------------------
// <copyright file="POSParameterMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// This Map class maps the map the POCO class POSParameter to table
    /// </summary>
    public class POSParameterMap : EntityTypeConfiguration<POSParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSParameterMap"/> class.
        /// </summary>
        public POSParameterMap()
        {
            ////Primary Key
            this.HasKey(t => t.Id);
            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");
            this.Property(t => t.ParameterName)
                .IsRequired()
                .HasMaxLength(50).HasColumnName("ParameterName");
            this.Property(t => t.DisplayOrder).IsRequired().HasColumnName("DisplayOrder");
            this.Property(t => t.IsActive).IsRequired().HasColumnName("IsActive");

            ////Relationships
            this.HasRequired(t => t.POSParameterCategory)
                .WithMany(x => x.POSParameters)
                .HasForeignKey(x => x.POSParameterCategoryId)
                .WillCascadeOnDelete(false);

            ////Table & Column Mappings
            this.ToTable("POSParameters");
        }
    }
}
