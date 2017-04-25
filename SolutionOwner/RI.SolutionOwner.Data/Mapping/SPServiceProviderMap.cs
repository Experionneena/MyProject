//---------------------------------------------------------
// <copyright file="SPServiceProviderMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

/// <summary>
/// The entity mapper.
/// </summary>
namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// The service provider entity papper.
    /// </summary>
    public class SPServiceProviderMap : EntityTypeConfiguration<SPServiceProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPServiceProviderMap"/> class.
        /// </summary>
        public SPServiceProviderMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ServiceProviderId");

            ToTable("SPServiceProviders");
        }
    }
}
