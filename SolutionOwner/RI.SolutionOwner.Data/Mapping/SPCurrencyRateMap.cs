// ---------------------------------------------------------
// <copyright file="SPCurrencyRateMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Class SPCurrencyRateMap
    /// </summary>
    public class SPCurrencyRateMap : EntityTypeConfiguration<SPCurrencyRate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyRateMap"/> class.
        /// </summary>
        public SPCurrencyRateMap()
        {
            this.ToTable("SPCurrencyRate");

            //// Primary Key
            this.HasKey(t => t.Id);

            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.CurrencyDescription)
                           .IsRequired()
                           .HasMaxLength(100)
                           .HasColumnName("Description")
                           .IsOptional();

            this.Property(t => t.Rate)
                          .IsRequired()
                          .HasPrecision(6, 3)
                          .HasColumnName("Rate");         

            this.Property(t => t.IsActive)
                         .IsRequired()
                         .HasColumnName("IsActive");

            this.HasRequired(t => t.SPCurrency)
                .WithMany(t => t.SPCurrencyRates)
                .HasForeignKey(t => t.CurrencyId)
                .WillCascadeOnDelete(false);
        }
    }
}
