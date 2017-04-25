//----------------------------------------------------------
// <copyright file="EntityTypeConfigurationExtension.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
// ----------------------------------------------------------

using System.Data.Entity.ModelConfiguration;
using RI.Framework.Core.Data.Entities;

namespace RI.SolutionOwner.Data.Extensions
{
    /// <summary>
    /// EntityTypeConfigurationExtension class
    /// </summary>
    public static class EntityTypeConfigurationExtension
    {
        /// <summary>
        /// Maps the specified entity type configuration.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="entityTypeConfiguration">The entity type configuration.</param>
        public static void Map<TContract>(this EntityTypeConfiguration<TContract> entityTypeConfiguration) where TContract : BaseEntity
        {
            entityTypeConfiguration.Property(t => t.CreatedDate)
                       .HasColumnType("datetime")
                       .HasColumnName("CreatedDate");

            entityTypeConfiguration.Property(t => t.EditedDate)                      
                       .HasColumnType("datetime")
                       .HasColumnName("EditedDate");
        }
    }
}
