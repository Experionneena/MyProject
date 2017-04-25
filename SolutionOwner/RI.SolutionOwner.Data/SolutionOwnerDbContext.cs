//---------------------------------------------------------------
// <copyright file="SolutionOwnerDbContext.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------------

using System;
using System.Data.Entity;
using RI.Framework.Audit.EntityFramework;
using RI.SolutionOwner.Data.Entities;
using RI.SolutionOwner.Data.Mapping;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data
{
    /// <summary>
    /// This class is the primary class that is responsible for interacting with data as object.
    /// </summary>
    public class SolutionOwnerDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionOwnerDbContext"/> class.
        /// </summary>
        public SolutionOwnerDbContext()
        {
            this.Database.Connection.ConnectionString = Environment.GetEnvironmentVariable("UserDatabaseConnectionString");       
            this.Database.CreateIfNotExists();
        }

        /// <summary>
        /// Gets or sets the solution owner users.
        /// </summary>
        /// <value>
        /// The solution owner users.
        /// </value>
        public DbSet<SOUser> SolutionOwnerUsers { get; set; }

        /// <summary>
        /// Gets or sets the solution owner menu option.
        /// </summary>
        /// <value>
        /// The solution owner menu option.
        /// </value>
        public DbSet<Entities.SOFeature> SolutionOwnerMenuOption { get; set; }

        /// <summary>
        /// Gets or sets the role feature permissions.
        /// </summary>
        /// <value>
        /// The role feature permissions.
        /// </value>
        public DbSet<SORolePermission> RoleFeaturePermissions { get; set; }

        /// <summary>
        /// Gets or sets the so user role.
        /// </summary>
        /// <value>
        /// The so user role.
        /// </value>
        public DbSet<SOUserRole> SOUserRole { get; set; }

        /// <summary>
        /// Gets or sets the audit log.
        /// </summary>
        /// <value>
        /// The audit log.
        /// </value>
        public DbSet<AuditLog> AuditLog { get; set; }

        /// <summary>
        /// Gets or sets the so category.
        /// </summary>
        /// <value>
        /// The so category.
        /// </value>
        public DbSet<SOCategory> SOCategory { get; set; }

        public DbSet<SPCategory> SPCategory { get; set; }

        public DbSet<POS> POS { get; set; }

        public DbSet<SPFeature> SPFeature { get; set; }

        public DbSet<SPRole> SPRole { get; set; }

        public DbSet<SPRolePermission> SPRolePermission { get; set; }

        /// <summary>
        /// Gets or sets the sp service providers.
        /// </summary>
        /// <value>
        /// The sp service providers.
        /// </value>
        public DbSet<SPServiceProvider> SPServiceProviders { get; set; }

        /// <summary>
        /// Gets or sets the sp product groups.
        /// </summary>
        /// <value>
        /// The sp product groups.
        /// </value>
        public DbSet<SPProductGroup> SPProductGroups { get; set; }

        public DbSet<Hierarchy> Hierarchy { get; set; }

        /// <summary>
        /// Gets or sets the position parameter categories.
        /// </summary>
        /// <value>
        /// The position parameter categories.
        /// </value>
        public DbSet<POSParameterCategory> POSParameterCategories { get; set; }

        /// <summary>
        /// Gets or sets the position parameters.
        /// </summary>
        /// <value>
        /// The position parameters.
        /// </value>
        public DbSet<POSParameter> POSParameters { get; set; }

        /// <summary>
        /// Gets or sets the so branding.
        /// </summary>
        /// <value>
        /// The so branding.
        /// </value>
        public DbSet<SOBranding> SOBranding { get; set; }

        /// <summary>
        /// Gets or sets the sp print template.
        /// </summary>
        /// <value>
        /// The sp print template.
        /// </value>
        public DbSet<SPPrintTemplate> SPPrintTemplate { get; set; }

        /// <summary>
        /// Gets or sets the sp currency.
        /// </summary>
        /// <value>
        /// The sp currency.
        /// </value>
        public DbSet<SPCurrency> SPCurrency { get; set; }

        /// <summary>
        /// Gets or sets the sp currency description.
        /// </summary>
        /// <value>
        /// The sp currency description.
        /// </value>
        public DbSet<SPCurrencyRate> SPCurrencyDescription { get; set; }

        /// <summary>
        /// Gets or sets the so solution partners.
        /// </summary>
        /// <value>
        /// The so solution partners.
        /// </value>
        public DbSet<SOSolutionPartner> SOSolutionPartners { get; set; }

        /// <summary>
        /// Gets or sets the so solution partner contacts.
        /// </summary>
        /// <value>
        /// The so solution partner contacts.
        /// </value>
        public DbSet<SOSolutionPartnerContact> SOSolutionPartnerContacts { get; set; }

        /// <summary>
        /// Gets or sets the SPHSP hierarchies.
        /// </summary>
        /// <value>
        /// The SPHSP hierarchies.
        /// </value>
        public DbSet<SPHierarchy> SPHSPHierarchies { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new SOUserMap());
            modelBuilder.Configurations.Add(new SOFeatureMap());
            modelBuilder.Configurations.Add(new SORolePermissionMap());
            modelBuilder.Configurations.Add(new SOUserRoleMap());
            modelBuilder.Configurations.Add(new SOCategoryMap());
            modelBuilder.Configurations.Add(new SPCategoryMap());
            modelBuilder.Configurations.Add(new SPFeatureMap());
            modelBuilder.Configurations.Add(new SPRolePermissionMap());
            modelBuilder.Configurations.Add(new SPRoleMap());;
            modelBuilder.Configurations.Add(new SOBrandingMap());
            modelBuilder.Configurations.Add(new SPPrintTemplateMap());
            modelBuilder.Configurations.Add(new SPServiceProviderMap());
            modelBuilder.Configurations.Add(new SPProductGroupMap());
            modelBuilder.Configurations.Add(new SPCurrencyMap());
            modelBuilder.Configurations.Add(new SPCurrencyRateMap());
            modelBuilder.Configurations.Add(new SOSolutionPartnerMap());
            modelBuilder.Configurations.Add(new SOSolutionPartnerContactMap());
            modelBuilder.Configurations.Add(new SPHierarchyMap());
            modelBuilder.Configurations.Add(new POSRegistrationMap());
        }
    }
}
