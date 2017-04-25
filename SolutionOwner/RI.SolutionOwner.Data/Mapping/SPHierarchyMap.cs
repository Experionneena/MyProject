//----------------------------------------------------------------------
// <copyright file="SPHierarchyMap.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RI.SolutionOwner.Data.Entities;

namespace RI.SolutionOwner.Data.Mapping
{
    /// <summary>
    /// This Map class maps the map the POCO class SPHeirarchy to table
    /// </summary>
    public class SPHierarchyMap : EntityTypeConfiguration<SPHierarchy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPHierarchyMap"/> class.
        /// </summary>
        public SPHierarchyMap()
        {
            //// Primary Key
            HasKey(x => x.Id);

            //Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");

            this.Property(t => t.EnableDistributor).HasColumnName("EnableDistributor");
            this.Property(t => t.EnableSubDistributor).HasColumnName("EnableSubDistributor");
            this.Property(t => t.EnableWholesaler).HasColumnName("EnableWholesaler");
            this.Property(t => t.EnableModernTrade).HasColumnName("EnableModernTrade");

            this.ToTable("SPHierarchies");
            ////this.HasRequired(t => t.SOSolutionPartner).WithRequiredDependent(y => y.SPHierarchy); 
            ////.WillCascadeOnDelete(true);/*.Map(m => m.MapKey("SolutionPartnerId"));*/
            ////this.HasRequired(t => t.SOSolutionPartner).WithRequiredDependent(y => y.SPHierarchy);
            ////.Map(m => m.MapKey("SolutionPartnerId"));
        }
    }
}
