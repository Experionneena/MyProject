//----------------------------------------------------------
// <copyright file="SPAddressMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// class SP Address Map
    /// </summary>
    public class SPAddressMap : EntityTypeConfiguration<SPAddress>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPAddressMap"/> class.
        /// </summary>
        public SPAddressMap()
        {
            this.ToTable("SPAddresses");

            // Primary Key
            this.HasKey(x => x.Id);

            this.Property(x => x.Address).HasMaxLength(150).HasColumnName("Address")
                                                           .IsRequired();

            this.Property(x => x.Street).HasMaxLength(25).HasColumnName("Street")
                                                         .IsOptional();

            this.Property(x => x.Area).HasMaxLength(25).HasColumnName("Area")
                                                       .IsOptional();

            this.Property(x => x.POBox).HasMaxLength(25).HasColumnName("POBox")
                                                        .IsRequired();

            this.Property(x => x.Zone).HasMaxLength(25).HasColumnName("Zone")
                                                       .IsOptional();

            this.Property(x => x.City).HasMaxLength(25).HasColumnName("City")
                                                       .IsRequired();

            this.Property(x => x.State).HasMaxLength(25).HasColumnName("State")
                                                        .IsRequired();

            this.Property(x => x.Country).HasMaxLength(25).HasColumnName("Country")
                                                          .IsRequired();

            this.Property(x => x.TimeZoneId).HasMaxLength(50).HasColumnName("TimeZoneId")
                                                             .IsOptional();

            this.Property(x => x.NFC).HasMaxLength(50).HasColumnName("NFC")
                                                      .IsOptional();

            this.Property(x => x.ContactPerson).HasMaxLength(100).HasColumnName("ContactPerson")
                                                                 .IsRequired();

            this.Property(x => x.MobileNumber).HasMaxLength(25).HasColumnName("MobileNumber")
                                                               .IsRequired(); 

            Property(x => x.ContactPersonEmail).HasMaxLength(100).HasColumnName("ContactPersonEmail");
        }
    }
}
