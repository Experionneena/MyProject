// ---------------------------------------------------------
// <copyright file="SPCurrencyMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//----------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// Class SPCurrencyMap to map table relations
    /// </summary>
    public class SPCurrencyMap : EntityTypeConfiguration<SPCurrency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCurrencyMap"/> class.
        /// </summary>
        public SPCurrencyMap()
        {
            this.ToTable("SPCurrency");
            //// Primary Key
            this.HasKey(t => t.Id);

            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.Currency)
                           .IsRequired()
                           .HasMaxLength(10)
                           .HasColumnName("Currency");

            this.Property(t => t.Symbol)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("Symbol");

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Description");
        }
    }
}
