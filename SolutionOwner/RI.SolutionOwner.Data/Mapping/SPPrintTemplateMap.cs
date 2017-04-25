//-----------------------------------------------------------
// <copyright file="SPPrintTemplateMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
namespace RI.SolutionOwner.Data.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RI.SolutionOwner.Data.Entities;

    /// <summary>
    /// This class maps the entity SPPrintTemplate to physical database
    /// </summary>
    public class SPPrintTemplateMap : EntityTypeConfiguration<SPPrintTemplate>
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="SPPrintTemplateMap"/> class.
        /// </summary>
        public SPPrintTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100).HasColumnName("TemplateName");
            this.Property(t => t.PrintText)
                .IsRequired().HasColumnType("nvarchar(max)")
                .HasColumnName("PrintText");
            this.Property(t => t.MerchantCopy).HasColumnName("MerchantCopy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.ToTable("SPPrintTemplate");
        }
    }
}
